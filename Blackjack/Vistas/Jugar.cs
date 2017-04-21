using Blackjack.Modelos;
using Blackjack.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Blackjack.Vistas
{
    public partial class Jugar : DevComponents.DotNetBar.Metro.MetroForm
    {
        private int sumaJugador;
        private int sumaDealer;
        private Baraja oBarajaJugador;
        private Baraja oBarajaDealer;
        Controladores.Partida oPartida;
        public Jugar()
        {
            InitializeComponent();
            sumaJugador = 0;
            sumaDealer = 0;
            oPartida = new Controladores.Partida();
            this.CenterToScreen();
            oBarajaJugador = new Baraja();
            oBarajaDealer = new Baraja();
            this.cargarUsuario();
            this.cargarDealer();
            this.resetear();
        }
        private void cargarUsuario()
        {
            txtJugador.Text = RunningData.Usuario.Nombre;
            imagenJugador.ImageLocation = RunningData.Usuario.Foto;
            int ganadas = oPartida.Select(RunningData.Usuario.Id, true);
            int perdidas = oPartida.Select(RunningData.Usuario.Id, false);
            txtGanadas.Text = ganadas.ToString();
            txtPerdidas.Text = perdidas.ToString();
            int totalPartidas = ganadas + perdidas;
            txtTotal.Text = totalPartidas.ToString();
        } 
        private void cargarDealer()
        {
           Result oDealer = ApiNames.obtenerDealerOtro();
            txtDealer.Text = Validations.CapitalizeFirstLetter(oDealer.name.first) + " " +
                Validations.CapitalizeFirstLetter(oDealer.name.last);
            imagenDealer.ImageLocation = oDealer.picture.medium;
        }
       
        private void empiezaJuego()
        {
            List<Carta> oList = API.requestCardStartGame(RunningData.Partida.Deck_Id);
            foreach (Carta item in oList)
            {
                this.mostarCartaJugador(item);
                oBarajaJugador.cartas.Add(item);
                sumaJugador = Validations.sumarCartas(oBarajaJugador);
            }

            oList = API.requestCardStartGame(RunningData.Partida.Deck_Id);
            foreach (Carta item in oList)
            {
                this.mostarCartaDealer(item);
                oBarajaDealer.cartas.Add(item);
                sumaDealer = Validations.sumarCartas(oBarajaDealer);
            }
        }

        private void btnNueva_Click_1(object sender, EventArgs e)
        {
            API.newGame();
            txtRestantes.Text = RunningData.Partida.Remaining.ToString();
            btnRebarajar.Visible = true;
            btnNueva.Visible = false;
        }

        private void btnPedir_Click(object sender, EventArgs e)
        {
            Carta oCarta = API.requestCard(RunningData.Partida.Deck_Id);
            this.mostarCartaJugador(oCarta);
            oBarajaJugador.cartas.Add(oCarta);
            sumaJugador = Validations.sumarCartas(oBarajaJugador);
            txtSuma.Text = sumaJugador.ToString();
            txtRestantes.Text = RunningData.Partida.Remaining.ToString();
            if (sumaJugador > 21)
            {
                CardDealer2.ImageLocation = oBarajaDealer.cartas[1].Image;
                MessageBox.Show("Lo Siento te pasas\n Dealer: " + sumaDealer);
                oPartida.Insert(RunningData.Partida.Deck_Id, RunningData.Usuario.Id, false);
                this.resetear();
            }
        }

        private void btnRebarajar_Click(object sender, EventArgs e)
        {
            API.reshuffleCards(RunningData.Partida.Deck_Id);
            txtRestantes.Text = RunningData.Partida.Remaining.ToString();
            this.empiezaJuego();
            txtSuma.Text = sumaJugador.ToString();
            btnPedir.Visible = true;
            btnPasar.Visible = true;
            btnRebarajar.Visible = false;
        }

        private void btnPasar_Click(object sender, EventArgs e)
        {
            if (sumaJugador < sumaDealer)
            {
                CardDealer2.ImageLocation = oBarajaDealer.cartas[1].Image;
                oPartida.Insert(RunningData.Partida.Deck_Id, RunningData.Usuario.Id, false);
                MessageBox.Show("Dealer gana!!\nPuntos: "+sumaDealer);
                this.resetear();
            }
            else if(sumaDealer < sumaJugador)
            {
                do
                {
                    Carta oCarta = API.requestCard(RunningData.Partida.Deck_Id);
                    this.mostarCartaDealer(oCarta);
                    oBarajaDealer.cartas.Add(oCarta);
                    sumaDealer = Validations.sumarCartas(oBarajaDealer);

                    if (sumaDealer == 21 && sumaDealer == sumaJugador)
                    {
                        CardDealer2.ImageLocation = oBarajaDealer.cartas[1].Image;
                        MessageBox.Show("Empate \nPuntos Dealer: " + sumaDealer);
                        break;
                    }
                    else if (sumaDealer == 21)
                    {
                        CardDealer2.ImageLocation = oBarajaDealer.cartas[1].Image;
                        oPartida.Insert(RunningData.Partida.Deck_Id, RunningData.Usuario.Id, false);
                        MessageBox.Show("Dealer Gana\nPuntos: " + sumaDealer);
                        break;
                    }
                    else if(sumaDealer > 21 )
                    {
                        CardDealer2.ImageLocation = oBarajaDealer.cartas[1].Image;
                        oPartida.Insert(RunningData.Partida.Deck_Id, RunningData.Usuario.Id, true);
                        MessageBox.Show("Felicidades!!\nPuntos Dealer: " + sumaDealer);
                        break;
                    }else txtRestantes.Text = RunningData.Partida.Remaining.ToString();
                    if (sumaDealer > sumaJugador)
                    {
                        CardDealer2.ImageLocation = oBarajaDealer.cartas[1].Image;
                        oPartida.Insert(RunningData.Partida.Deck_Id, RunningData.Usuario.Id, false);
                        MessageBox.Show("Dealer Gana\nPuntos: " + sumaDealer);
                        break;
                    }
                } while (sumaDealer<= sumaJugador);
                this.resetear();
            }
        }

        private void mostarCartaDealer(Carta pCarta)
        {
            switch (oBarajaDealer.cartas.Count)
            {
                case 0:
                    CardDealer1.Visible = true;
                    CardDealer1.ImageLocation = pCarta.Image;
                    break;
                case 1:
                    CardDealer2.Visible = true;
                    CardDealer2.Image = Image.FromFile(@"C:\Users\Kevin Arias\Documents\Visual Studio 2015\Projects\Blackjack\Blackjack\Imagenes\CartaOculta.png");
                    break;
                case 2:
                    CardDealer3.Visible = true;
                    CardDealer3.ImageLocation = pCarta.Image;
                    break;
                case 3:
                    CardDealer4.Visible = true;
                    CardDealer4.ImageLocation = pCarta.Image;
                    break;
                case 4:
                    CardDealer5.Visible = true;
                    CardDealer5.ImageLocation = pCarta.Image;
                    break;
                case 5:
                    CardDealer6.Visible = true;
                    CardDealer6.ImageLocation = pCarta.Image;
                    break;
            }
        }
        private void mostarCartaJugador(Carta pCarta)
        {
            switch (oBarajaJugador.cartas.Count)
            {
                case 0:
                    Card1.Visible = true;
                    Card1.ImageLocation = pCarta.Image;
                    break;
                case 1:
                    Card2.Visible = true;
                    Card2.ImageLocation = pCarta.Image;
                    break;
                case 2:
                    Card3.Visible = true;
                    Card3.ImageLocation = pCarta.Image;
                    break;
                case 3:
                    Card4.Visible = true;
                    Card4.ImageLocation = pCarta.Image;
                    break;
                case 4:
                    Card5.Visible = true;
                    Card5.ImageLocation = pCarta.Image;
                    break;
                case 5:
                    Card6.Visible = true;
                    Card6.ImageLocation = pCarta.Image;
                    break;
            }
        }
        private void resetear()
        {
            this.ocultarPictureBox();
            sumaJugador = 0;
            sumaDealer = 0;
            oBarajaDealer.cartas = new List<Carta>();
            oBarajaJugador.cartas = new List<Carta>();
            txtRestantes.Text = "";
            txtSuma.Text = "";
            btnPasar.Visible = false;
            btnPedir.Visible = false;
            btnRebarajar.Visible = false;
            btnNueva.Visible = true;
            this.cargarUsuario();
            this.cargarDealer();
        }
        private void ocultarPictureBox()
        {
            Card1.Image = null;
            Card2.Image = null;
            Card3.Image = null;
            Card4.Image = null;
            Card5.Image = null;
            Card6.Image = null;
            CardDealer1.Image = null;
            CardDealer2.Image = null;
            CardDealer3.Image = null;
            CardDealer4.Image = null;
            CardDealer5.Image = null;
            CardDealer6.Image = null;
            Card1.Visible = false;
            Card2.Visible = false;
            Card3.Visible = false;
            Card4.Visible = false;
            Card5.Visible = false;
            Card6.Visible = false;
            CardDealer1.Visible = false;
            CardDealer2.Visible = false;
            CardDealer3.Visible = false;
            CardDealer4.Visible = false;
            CardDealer5.Visible = false;
            CardDealer6.Visible = false;
        }
 
    }
}
