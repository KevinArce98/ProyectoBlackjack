using Blackjack.Modelos;
using System.Collections.Generic;

namespace Blackjack.Utils
{
   public class Validations
    {

        public static int sumarCartas(Baraja oBaraja)
        {
            List<Carta> oListAce = new List<Carta>();
            int suma = 0;
            foreach (Carta item in oBaraja.cartas)
            {
                if (item.Value.Equals("QUEEN") || item.Value.Equals("KING") || item.Value.Equals("JACK"))
                {
                    suma += 10;
                }
                else if (item.Value.Equals("ACE"))
                {
                    oListAce.Add(item);
                }
                else
                {
                    suma += int.Parse(item.Value);
                }
            }
            foreach (Carta item in oListAce)
            {
                if (suma <= 10)
                {
                    suma += 11;
                }
                else if(suma > 10)
                {
                    suma += 1;
                }
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
        public static void verificaUsuario(Usuario oUsuario)
        {

        }
    }
}
