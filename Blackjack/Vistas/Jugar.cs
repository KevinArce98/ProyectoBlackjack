using Blackjack.Modelos;
using Blackjack.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Blackjack.Vistas
{
    public partial class Jugar : Form
    {
        private int suma;
        public Jugar()
        {
            InitializeComponent();
            suma = 0;
        }
        private void empiezaJuego()
        {
            List<Carta> oList = API.requestCardStartGame(RunningData.Partida.Deck_Id);
            foreach (Carta item in oList)
            {
                this.mostarCarta(item);
                suma += Validations.sumarCartas(item);
            }
        }
     
        private void btnNueva_Click(object sender, EventArgs e)
        {
            this.resetear();
            API.newGame();
            txtRestantes.Text = RunningData.Partida.Remaining.ToString();
            this.empiezaJuego();
            txtSuma.Text = suma.ToString();
            if (Validations.verificaGanada(suma) == true)
            {
                MessageBox.Show("Blackjack");
            }
            btnPedir.Visible = true;
            btnRebarajar.Visible = true; 
        }

        private void btnPedir_Click(object sender, EventArgs e)
        {
            Carta oCarta = API.requestCard(RunningData.Partida.Deck_Id);
            this.mostarCarta(oCarta);
            suma += Validations.sumarCartas(oCarta);
            txtSuma.Text = suma.ToString();
            txtRestantes.Text = RunningData.Partida.Remaining.ToString();
        }

        private void btnRebarajar_Click(object sender, EventArgs e)
        {
            API.reshuffleCards(RunningData.Partida.Deck_Id);
            txtRestantes.Text = RunningData.Partida.Remaining.ToString();
        }
        private void mostarCarta(Carta pCarta)
        {
            switch (RunningData.ContadorCartas)
            {
                case 0:
                    Card1.ImageLocation = pCarta.Image;
                    RunningData.ContadorCartas++;
                    break;
                case 1:
                    Card2.ImageLocation = pCarta.Image;
                    RunningData.ContadorCartas++;
                    break;
                case 2:
                    Card3.ImageLocation = pCarta.Image;
                    RunningData.ContadorCartas++;
                    break;
                case 3:
                    Card4.ImageLocation = pCarta.Image;
                    RunningData.ContadorCartas++;
                    break;
                case 4:
                    Card5.ImageLocation = pCarta.Image;
                    RunningData.ContadorCartas++;
                    break;
                case 5:
                    Card6.ImageLocation = pCarta.Image;
                    RunningData.ContadorCartas++;
                    break;
                case 6:
                    Card7.ImageLocation = pCarta.Image;
                    RunningData.ContadorCartas++;
                    break;
                case 7:
                    Card8.ImageLocation = pCarta.Image;
                    RunningData.ContadorCartas++;
                    break;
                case 8:
                    Card9.ImageLocation = pCarta.Image;
                    RunningData.ContadorCartas++;
                    break;
                case 9:
                    Card10.ImageLocation = pCarta.Image;
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
            Card7.Image = null;
            Card8.Image = null;
            Card9.Image = null;
            Card10.Image = null;
            RunningData.ContadorCartas = 0;
            suma = 0;
        }
    }
}
