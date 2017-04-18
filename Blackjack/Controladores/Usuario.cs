using System.Data;


namespace Blackjack.Controladores
{
    public class Usuario : DBAccess.ErrorHandler
    {
        private Modelos.Usuario oUsuario;
        public Usuario()
        {
            oUsuario = new Modelos.Usuario();
        }
        public Modelos.Usuario Select(string pCorreo)
        {
            DataTable result = new DataTable();
            result = this.oUsuario.Select(pCorreo);
            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                this.oUsuario.Id = int.Parse(row["id"].ToString());
                this.oUsuario.Correo = row["correo"].ToString();
                this.oUsuario.Nombre = row["nombre"].ToString();
                this.oUsuario.Foto = row["foto"].ToString();
            }
            else
            {
                this.oUsuario.Id = -1;
            }
            if (this.oUsuario.isError)
            {
                this.isError = true;
                this.errorDescription = this.oUsuario.errorDescription;
            }
            return oUsuario;
        }

        public void Insert(string pCorreo, string pNombre, string pFoto)
        {
            this.oUsuario = new Modelos.Usuario(pCorreo, pNombre, pFoto);
            this.oUsuario.Insert();
            if (this.oUsuario.isError)
            {
                this.isError = true;
                this.errorDescription = this.oUsuario.errorDescription;
            }
        }
    }
}
