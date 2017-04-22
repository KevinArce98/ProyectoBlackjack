using System.Collections.Generic;

namespace Blackjack.Modelos
{
    public class Baraja
    {
        public int IdJugador { get; set; }
        public List<Carta> cartas { get; set; }

        public Baraja()
        {
            cartas = new List<Carta>();
        }
    }
}
