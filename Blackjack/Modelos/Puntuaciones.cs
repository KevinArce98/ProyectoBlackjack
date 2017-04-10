using System;
using System.Collections.Generic;
using System.Data;

namespace Blackjack.Modelos
{
    public class Puntuaciones : DBAccess.ErrorHandler
    {
        public int Id { get; set; }
        public string Correo { get; set; }
        public int Ganadas { get; set; }
        public int Perdidas { get; set; }

        public Puntuaciones(string pCorreo)
        {
            this.Correo = pCorreo;
            this.Ganadas = 0;
            this.Perdidas = 0;
        }
        public Puntuaciones(int ganadas, int perdidas)
        {
            this.Correo = "";
            this.Ganadas = ganadas;
            this.Perdidas = perdidas;
        }
        public Puntuaciones()
        {
                
        }

        public DataTable Select(string pCorreo)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("correo", pCorreo);

            string sql = "SELECT * FROM partidas WHERE correo = @correo";
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
            parametros.Add("correo", this.Correo);

            DataTable result = Program.da.SqlQuery("insert into partidas (correo) "
                + "values (@correo) returning id;", parametros);
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

        public void Update(string pCorreo)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("ganadas", this.Ganadas);
            parametros.Add("perdidas", this.Perdidas);
            parametros.Add("correo", pCorreo);

            Program.da.SqlStatement("update partidas set ganadas=@ganadas, perdidas=@perdidas "
                + "where correo = @correo", parametros);
            if (Program.da.isError)
            {
                this.isError = true;
                this.errorDescription = Program.da.errorDescription;
                return;
            }
        }
    }
}
