using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
