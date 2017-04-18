using Blackjack.Controladores;
using Blackjack.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blackjack.Vistas
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.buscaUsuario();
        }
        private void buscaUsuario()
        {
            Usuario oUsuario = new Usuario();
            Modelos.Usuario oUsuarioM = oUsuario.Select(RunningData.Usuario.Correo);
            if (oUsuarioM.Id == -1)
            {
                oUsuario.Insert(RunningData.Usuario.Correo, RunningData.Usuario.Nombre, RunningData.Usuario.Foto);
                RunningData.Usuario = oUsuario.Select(RunningData.Usuario.Correo);
            }
            else
            {
                RunningData.Usuario = oUsuarioM;
            }
        }


        private void btnJugar_Click(object sender, EventArgs e)
        {
            Jugar frmJugar = new Jugar();
            frmJugar.ShowDialog();
        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Historial frm = new Historial();
            frm.ShowDialog();
        }
    }
}
