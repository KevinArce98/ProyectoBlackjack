using System;
using System.Collections.Generic;
using System.Data;

namespace Blackjack.Modelos
{
    public class Usuario : DBAccess.ErrorHandler
    {
        public int Id { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string Foto { get; set; }

        public Usuario(string pCorreo, string pNombre, string pFoto)
        {
            this.Correo = pCorreo;
            this.Nombre = pNombre;
            this.Foto = pFoto;
        }

        public Usuario()
        {

        }

        public DataTable Select(string pCorreo)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("correo", pCorreo);

            string sql = "SELECT * FROM usuario WHERE correo = @correo ";
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
            parametros.Add("nombre", this.Nombre);
            parametros.Add("correo", this.Correo);
            parametros.Add("foto", this.Foto);

            DataTable result = Program.da.SqlQuery("insert into usuario (nombre, correo, foto) "
                + "values (@nombre, @correo, @foto) returning id;", parametros);
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
    }
}
