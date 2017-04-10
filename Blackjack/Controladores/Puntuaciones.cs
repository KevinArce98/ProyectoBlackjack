using System.Data;

namespace Blackjack.Controladores
{
    class Puntuaciones : DBAccess.ErrorHandler
    {
        private Modelos.Puntuaciones oPuntuaciones;
        public Puntuaciones()
        {
            oPuntuaciones = new Modelos.Puntuaciones(); 
        }
        public Modelos.Puntuaciones Select(string correo)
        {
            DataTable result = new DataTable();
            result = this.oPuntuaciones.Select(correo);
            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                this.oPuntuaciones.Id = int.Parse(row["id"].ToString());
                this.oPuntuaciones.Correo = row["correo"].ToString();
                this.oPuntuaciones.Ganadas = int.Parse(row["ganadas"].ToString());
                this.oPuntuaciones.Perdidas = int.Parse(row["perdidas"].ToString());
            }
            else
            {
                this.oPuntuaciones.Id = -1;
                this.Insert(correo);
            }

            if (this.oPuntuaciones.isError)
            {
                this.isError = true;
                this.errorDescription = this.oPuntuaciones.errorDescription;
            }
            return oPuntuaciones;
        }

        public void Insert(string pCorreo)
        {
            this.oPuntuaciones = new Modelos.Puntuaciones(pCorreo);
            this.oPuntuaciones.Insert();
            if (this.oPuntuaciones.isError)
            {
                this.isError = true;
                this.errorDescription = this.oPuntuaciones.errorDescription;
            }
        }

        public void Update(string pCorreo, int ganadas, int perdidas)
        {
            this.oPuntuaciones = new Modelos.Puntuaciones(ganadas,perdidas);
            this.oPuntuaciones.Update(pCorreo);
            if (this.oPuntuaciones.isError)
            {
                this.isError = true;
                this.errorDescription = this.oPuntuaciones.errorDescription;
            }
        }

      
        }
}
