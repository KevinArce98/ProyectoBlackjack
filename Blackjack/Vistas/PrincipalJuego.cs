using System;
using System.Windows.Forms;
using Facebook;
using Blackjack.Modelos;

namespace Blackjack.Vistas
{
    public partial class PrincipalJuego : DevComponents.DotNetBar.Metro.MetroForm
    {

        private const string AppId = "461471847525252";
        private const string ExtendedPermissions = "email, public_profile";
        private string _accessToken;

        public PrincipalJuego()
        {
            InitializeComponent();
        }

        private void btnLoginFacebook_Click(object sender, EventArgs e)
        {
            var fbLoginDialog = new FacebookLoginDialog(AppId, ExtendedPermissions);
            fbLoginDialog.ShowDialog();

            DisplayAppropriateMessage(fbLoginDialog.FacebookOAuthResult);
        }

        private void DisplayAppropriateMessage(FacebookOAuthResult facebookOAuthResult)
        {
            if (facebookOAuthResult != null)
            {
                if (facebookOAuthResult.IsSuccess)
                {
                    _accessToken = facebookOAuthResult.AccessToken;
                    Program.tokenFacebook = _accessToken;

                    var fb = new FacebookClient(facebookOAuthResult.AccessToken);
                    
                    dynamic me = fb.Get("/me?fields=name,email,picture");
                    
                    // for .net 3.5
                    //var result = (IDictionary<string, object>)fb.Get("/me");
                    //var name = (string)result["name"];


                    //-------------------------------------//
                    //su usuario para que lo haga un rollito y....

                    Usuario oUsuario = new Usuario();
                    oUsuario.Correo = me.email;
                    oUsuario.Nombre = me.name;
                    oUsuario.Foto = me.picture.data.url;
                    Utils.RunningData.Usuario = oUsuario;
                    Principal frm = new Principal();
                    frm.Show();
                    this.Hide();
                    //this.imgPerfil.ImageLocation = me.picture.data.url;
                    //MessageBox.Show("Hi " + me.name + "\n" + me.email);
                    //btnLogOut.Visible = true;
                    //aqui se va a llamar al form del juego una vez que entre bb

                }
                else
                {
                    MessageBox.Show(facebookOAuthResult.ErrorDescription);
                }
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            var webBrowser = new WebBrowser();
            var fb = new FacebookClient();
            var logouUrl = fb.GetLogoutUrl(new { access_token = _accessToken, next = "https://www.facebook.com/connect/login_success.html" });
            webBrowser.Navigate(logouUrl);
            //btnLogOut.Visible = false;
        }

        public void logoutFacebook()
        {
            var webBrowser = new WebBrowser();
            var fb = new FacebookClient();
            var logouUrl = fb.GetLogoutUrl(new { access_token = Program.tokenFacebook, next = "https://www.facebook.com/connect/login_success.html" });
            webBrowser.Navigate(logouUrl);
            //btnLogOut.Visible = false;
        }
    }
}
