using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Modelos
{
    public class Partida : DBAccess.ErrorHandler
    {
        public int Id { get; set; }
        public string Deck_Id { get; set; }
        public int IdJugador { get; set; }
        public DateTime Fecha { get; set; }
        public bool Gano { get; set; }

        public Partida(string pDeck, int pIdJugador, bool pGano)
        {
            this.Deck_Id = pDeck;
            this.IdJugador = pIdJugador;
            this.Gano = pGano;
        }
        public Partida()
        {
                
        }
        public DataTable Select(int pIdJugador, bool pGanadas)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("id_jugador", pIdJugador);
            parametros.Add("gano", pGanadas);

            string sql = "SELECT count(*) FROM partidas WHERE id_jugador = @id_jugador AND gano = @gano;";
            DataTable result = Program.da.SqlQuery(sql, parametros);
            if (Program.da.isError)
            {
                this.isError = true;
                this.errorDescription = Program.da.errorDescription;
            }
            return result;
        }

        public void Insert()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("deck_id", this.Deck_Id);
            parametros.Add("id_jugador", this.IdJugador);
            parametros.Add("gano", this.Gano);

            DataTable result = Program.da.SqlQuery("INSERT INTO partidas(deck_id, id_jugador, fecha, gano) "+
                "VALUES (@deck_id, @id_jugador, NOW(), @gano) returning id;", parametros);
            if (Program.da.isError)
            {
                this.isError = true;
                this.errorDescription = Program.da.errorDescription;
                return;
            }
            if (result.Rows.Count > 0)
            {
                this.Id = Convert.ToInt32(result.Rows[0]["id"]);
            }
        }

        public DataTable SelectHistorial()
        {
            string sql = "SELECT * FROM partidas";
            DataTable result = Program.da.SqlQuery(sql, new Dictionary<string, object>());
            if (Program.da.isError)
            {
                this.isError = true;
                this.errorDescription = Program.da.errorDescription;
            }
            return result;
        }
    }
}
