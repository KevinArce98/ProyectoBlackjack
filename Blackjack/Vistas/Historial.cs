using Blackjack.Controladores;


namespace Blackjack.Vistas
{
    public partial class Historial : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Historial()
        {
            InitializeComponent();
            this.cargarTablaYChart();
            this.CenterToScreen();
        }
        private void cargarTablaYChart()
        {
            Partida oPartida = new Partida();
            dtgHistorial.DataSource = oPartida.SelectHistorial();
            chart1.DataSource = oPartida.SelectData();
            chart1.Series[0].XValueMember = "nombre";
            chart1.Series[0].YValueMembers = "ganadas";
        }
    }
}
