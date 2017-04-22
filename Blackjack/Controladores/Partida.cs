using System.Data;
namespace Blackjack.Controladores
{
    public class Partida : DBAccess.ErrorHandler
    {
        public Modelos.Partida oPartida { get; set; }

        public Partida()
        {
            oPartida = new Modelos.Partida();
        }

        public int Select(int idJugador, bool ganadas)
        {
            DataTable result = new DataTable();
            int total = 0;
            result = this.oPartida.Select(idJugador, ganadas);
            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
               total = int.Parse(row["count"].ToString());
            }
            if (this.oPartida.isError)
            {
                this.isError = true;
                this.errorDescription = this.oPartida.errorDescription;
            }
            return total;
        }

        public DataTable SelectHistorial()
        {
            DataTable result = new DataTable();
            result = this.oPartida.SelectHistorial();
            if (this.oPartida.isError)
            {
                this.isError = true;
                this.errorDescription = this.oPartida.errorDescription;
            }
            return result;
        }

        public DataTable SelectData()
        {
            DataTable result = new DataTable();
            result = this.oPartida.SelectData();
            if (this.oPartida.isError)
            {
                this.isError = true;
                this.errorDescription = this.oPartida.errorDescription;
            }
            return result;
        }

        public void Insert(string pDeck, int pIdJugador, bool pGano)
        {
            this.oPartida = new Modelos.Partida(pDeck, pIdJugador, pGano);
            this.oPartida.Insert();
            if (this.oPartida.isError)
            {
                this.isError = true;
                this.errorDescription = this.oPartida.errorDescription;
            }
        }
    }
}
