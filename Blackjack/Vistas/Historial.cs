using Blackjack.Controladores;


namespace Blackjack.Vistas
{
    public partial class Historial : DevComponents.DotNetBar.Metro.MetroForm
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
