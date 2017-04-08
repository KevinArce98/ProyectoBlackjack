using System.Collections.Generic;


namespace Blackjack.Modelos
{
    public class Carta
    {
        public string Code { get; set; }
        public string Image { get; set; }
        public string Value { get; set; }

        public Carta()
        {
                
        }
    }
    public class RootObjectCards
    {
        public int remaining { get; set; }
        public List<Carta> cards { get; set; }
        public string deck_id { get; set; }
        public bool success { get; set; }
    }

}
