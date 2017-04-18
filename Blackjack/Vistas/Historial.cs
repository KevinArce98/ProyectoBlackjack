using Blackjack.Controladores;
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
    public partial class Historial : Form
    {
        public Historial()
        {
            InitializeComponent();
            this.cargarTabla();
        }
        private void cargarTabla()
        {
            Partida oPartida = new Partida();
            dtgHistorial.DataSource = oPartida.SelectHistorial();
        }
    }
}
