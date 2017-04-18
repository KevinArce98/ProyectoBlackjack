using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Modelos
{
    public class Dealer : DBAccess.ErrorHandler
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Dealer()
        {

        }
        public DataTable Select(int id)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("id", id);

            string sql = "SELECT * FROM dealer WHERE id = @id ";
            DataTable result = Program.da.SqlQuery(sql, parametros);
            if (Program.da.isError)
            {
                this.isError = true;
                this.errorDescription = Program.da.errorDescription;
            }
            return result;
        }
    }

}
