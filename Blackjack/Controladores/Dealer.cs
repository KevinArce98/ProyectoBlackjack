
using System.Data;

namespace Blackjack.Controladores
{
    public class Dealer : DBAccess.ErrorHandler
    {
        public Modelos.Dealer oDealer { get; set; }
        public Dealer()
        {
            oDealer = new Modelos.Dealer();
        }
        public Modelos.Dealer Select(int id)
        {
            DataTable result = new DataTable();
            result = this.oDealer.Select(id);
            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                this.oDealer.Id = int.Parse(row["id"].ToString());
                this.oDealer.Nombre = row["nombre"].ToString();
            }
            else
            {
                this.oDealer.Id = -1;
                this.oDealer.Nombre = "ADMIN";
            }
            if (this.oDealer.isError)
            {
                this.isError = true;
                this.errorDescription = this.oDealer.errorDescription;
            }
            return oDealer;
        }
    }
}
