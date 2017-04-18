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
        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            Jugar frmJugar = new Jugar();
            frmJugar.ShowDialog();
        }
    }
}
