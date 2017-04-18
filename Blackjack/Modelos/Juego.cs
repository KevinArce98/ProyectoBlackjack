
namespace Blackjack.Modelos
{
    class Juego
    {
        public bool Shuffled { get; set; }
        public int Remaining { get; set; }
        public string Deck_Id { get; set; }
        public bool Success { get; set; }

        public Juego()
        {

        }


        public class RootObjectGame
        {
            public bool shuffled { get; set; }
            public int remaining { get; set; }
            public string deck_id { get; set; }
            public bool success { get; set; }
        }
    }
}
