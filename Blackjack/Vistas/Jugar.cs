using Blackjack.Modelos;
using Blackjack.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Blackjack.Vistas
{
    public partial class Jugar : Form
    {
        private int sumaJugador;
        private int sumaDealer;
        private Baraja oBarajaJugador;
        private Baraja oBarajaDealer;
        private Controladores.Puntuaciones oPuntuacion;
        public Jugar()
        {
            InitializeComponent();
            sumaJugador = 0;
            sumaDealer = 0;
            oBarajaJugador = new Baraja();
            oBarajaDealer = new Baraja();
            oPuntuacion = new Controladores.Puntuaciones();
            this.buscarPuntuaciones();
        }
        private void buscarPuntuaciones()
        {
            txtJugador.Text = "arias9068@gmail.com";
            Puntuaciones oPuntuaciones = oPuntuacion.Select("arias9068@gmail.com");
            if (oPuntuaciones.Id != -1)
            {
                txtGanadas.Text = oPuntuaciones.Ganadas.ToString();
                txtPerdidas.Text = oPuntuaciones.Perdidas.ToString();
            }
            else
            {
                txtGanadas.Text = "0";
                txtPerdidas.Text = "0";
            }
        }
        private void empiezaJuegoJugador()
        {
            List<Carta> oList = API.requestCardStartGame(RunningData.Partida.Deck_Id);
            foreach (Carta item in oList)
            {
                this.mostarCartaJugador(item);
                oBarajaJugador.cartas.Add(item);
                sumaJugador += Validations.sumarCartas(item, sumaJugador);
            }
        }
        private void empiezaJuegoDealer()
        {
            List<Carta> oList = API.requestCardStartGame(RunningData.Partida.Deck_Id);
            foreach (Carta item in oList)
            {
                this.mostarCartaDealer(item);
                oBarajaDealer.cartas.Add(item);
                sumaDealer += Validations.sumarCartas(item, sumaDealer);
            }
        }
     
        private void btnNueva_Click(object sender, EventArgs e)
        {
            this.resetear();
            API.newGame();
            txtRestantes.Text = RunningData.Partida.Remaining.ToString();
            this.empiezaJuegoJugador();
            this.empiezaJuegoDealer();
            txtSuma.Text = sumaJugador.ToString();
            if (Validations.verificaGanada(sumaJugador) == true)
            {
                CardDealer2.ImageLocation = oBarajaDealer.cartas[1].Image;
                MessageBox.Show("Blackjack");
            }
            else
            {
                btnPedir.Visible = true;
                btnRebarajar.Visible = true;
                btnPasar.Visible = true;
            }
        }

        private void btnPedir_Click(object sender, EventArgs e)
        {
            Carta oCarta = API.requestCard(RunningData.Partida.Deck_Id);
            this.mostarCartaJugador(oCarta);
            oBarajaJugador.cartas.Add(oCarta);
            sumaJugador += Validations.sumarCartas(oCarta, sumaJugador);
            txtSuma.Text = sumaJugador.ToString();
            txtRestantes.Text = RunningData.Partida.Remaining.ToString();
            if (sumaJugador > 21)
            {
                CardDealer2.ImageLocation = oBarajaDealer.cartas[1].Image;
                oPuntuacion.Update(txtJugador.Text, int.Parse(txtGanadas.Text), (int.Parse(txtPerdidas.Text) + 1));
                MessageBox.Show("Lo Siento te pasas\n Dealer: " +sumaDealer);
                this.resetear();
            }else if (sumaJugador == 21)
            {
                CardDealer2.ImageLocation = oBarajaDealer.cartas[1].Image;
                oPuntuacion.Update(txtJugador.Text, (int.Parse(txtGanadas.Text)+1), (int.Parse(txtPerdidas.Text)));
                MessageBox.Show("Felicidades\nPuntos Dealer: " + sumaDealer);
                this.resetear();
            }
        }

        private void btnRebarajar_Click(object sender, EventArgs e)
        {
            API.reshuffleCards(RunningData.Partida.Deck_Id);
            txtRestantes.Text = RunningData.Partida.Remaining.ToString();
        }
        private void mostarCartaJugador(Carta pCarta)
        {
            switch (oBarajaJugador.cartas.Count)
            {
                case 0:
                    Card1.ImageLocation = pCarta.Image;
                    break;
                case 1:
                    Card2.ImageLocation = pCarta.Image; 
                    break;
                case 2:
                    Card3.ImageLocation = pCarta.Image;
                    break;
                case 3:
                    Card4.ImageLocation = pCarta.Image;
                    break;
                case 4:
                    Card5.ImageLocation = pCarta.Image;
                    break;
                case 5:
                    Card6.ImageLocation = pCarta.Image;
                    break;
            }
        }
        private void resetear()
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
            sumaJugador = 0;
            sumaDealer = 0;
            oBarajaDealer.cartas = new List<Carta>();
            oBarajaJugador.cartas = new List<Carta>();
            txtRestantes.Text = "";
            txtSuma.Text = "";
            btnPasar.Visible = false;
            btnPedir.Visible = false;
            btnRebarajar.Visible = false;
        }

        private void btnPasar_Click(object sender, EventArgs e)
        {
            if (sumaJugador < sumaDealer)
            {
                CardDealer2.ImageLocation = oBarajaDealer.cartas[1].Image;
                oPuntuacion.Update(txtJugador.Text, int.Parse(txtGanadas.Text), (int.Parse(txtPerdidas.Text) + 1));
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
                    sumaDealer += Validations.sumarCartas(oCarta, sumaDealer);
                    txtRestantes.Text = RunningData.Partida.Remaining.ToString();
                    if (sumaDealer == 21)
                    {
                        CardDealer2.ImageLocation = oBarajaDealer.cartas[1].Image;
                        oPuntuacion.Update(txtJugador.Text, int.Parse(txtGanadas.Text), (int.Parse(txtPerdidas.Text) + 1));
                        MessageBox.Show("Dealer Gana\nPuntos: " + sumaDealer);
                        break;
                    }
                    else if(sumaDealer > 21 )
                    {
                        CardDealer2.ImageLocation = oBarajaDealer.cartas[1].Image;
                        oPuntuacion.Update(txtJugador.Text, (int.Parse(txtGanadas.Text) + 1), (int.Parse(txtPerdidas.Text)));
                        MessageBox.Show("Felicidades!!\nPuntos Dealer: " + sumaDealer);
                        break;
                    }
                } while (sumaDealer<= sumaJugador);
            }
        }

        private void mostarCartaDealer(Carta pCarta)
        {
            switch (oBarajaDealer.cartas.Count)
            {
                case 0:
                    CardDealer1.ImageLocation = pCarta.Image;
                    break;
                case 1:
                    CardDealer2.Image = Image.FromFile(@"C:\Users\Kevin Arias\Documents\Visual Studio 2015\Projects\Blackjack\Blackjack\Imagenes\CartaOculta.png");
                    break;
                case 2:
                    CardDealer3.ImageLocation = pCarta.Image;
                    break;
                case 3:
                    CardDealer4.ImageLocation = pCarta.Image;
                    break;
                case 4:
                    CardDealer5.ImageLocation = pCarta.Image;
                    break;
                case 5:
                    CardDealer6.ImageLocation = pCarta.Image;
                    break;
            }
        }
    }
}
