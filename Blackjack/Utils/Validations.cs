using Blackjack.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Utils
{
   public class Validations
    {

        public static int sumarCartas(Carta oCarta, int sumaTotal)
        {
            int suma = 0;
            if (oCarta.Value.Equals("QUEEN") || oCarta.Value.Equals("KING") || oCarta.Value.Equals("JACK"))
            {
                suma += 10;
            }
            else if (oCarta.Value.Equals("ACE"))
            {
                if (sumaTotal < 6)
                {
                    suma += 1;
                }
                else
                {
                    suma += 11;
                }
            }
            else
            {
                suma += int.Parse(oCarta.Value);
            }
            return suma;
        }

        public static bool verificaGanada(int suma)
        {
            bool gano = false;
            if (suma == 21)
            {
                gano = true;
            }
            return gano;
        }
    }
}
