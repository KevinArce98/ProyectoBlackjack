using System.Collections.Generic;

namespace Blackjack.Modelos
{
    public class Dealer
    {
    }

    public class Name
    {
        public string title { get; set; }
        public string first { get; set; }
        public string last { get; set; }
    }

    public class Picture
    {
        public string large { get; set; }
        public string medium { get; set; }
        public string thumbnail { get; set; }
    }

    public class Result
    {
        public Name name { get; set; }
        public Picture picture { get; set; }
    }

    public class Info
    {
        public string seed { get; set; }
        public int results { get; set; }
        public int page { get; set; }
        public string version { get; set; }
    }

    public class RootObjectDealerOtro
    {
        public List<Result> results { get; set; }
        public Info info { get; set; }
    }

}
