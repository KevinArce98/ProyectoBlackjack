using Blackjack.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Blackjack.Modelos
{
    class API
    {

        public static Carta requestCard(string code)
        {
             Uri uri = new Uri(@"https://deckofcardsapi.com/api/deck/"+code+ "/draw/?count=1");
            WebRequest webRequest = WebRequest.Create(uri);
             WebResponse response = webRequest.GetResponse();
             StreamReader streamReader = new StreamReader(response.GetResponseStream());
             String responseData = streamReader.ReadToEnd();
             var outObject = JsonConvert.DeserializeObject<RootObjectCards>(responseData);
            Carta oCarta = (Carta)outObject.cards[0];
            RunningData.Partida.Remaining = outObject.remaining;
            return oCarta;
        }
        public static List<Carta> requestCardStartGame(string code)
        {
            List<Carta> oList = new List<Carta>();
            Uri uri = new Uri(@"https://deckofcardsapi.com/api/deck/" + code + "/draw/?count=2");
            WebRequest webRequest = WebRequest.Create(uri);
            WebResponse response = webRequest.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream());
            String responseData = streamReader.ReadToEnd();
            var outObject = JsonConvert.DeserializeObject<RootObjectCards>(responseData);
            Carta oCarta = (Carta)outObject.cards[0];
            oList.Add(oCarta);
            oCarta = (Carta)outObject.cards[1];
            oList.Add(oCarta);
            RunningData.Partida.Remaining = outObject.remaining;
            return oList;
        }

        public static void newGame()
        {
            Uri uri = new Uri(@"https://deckofcardsapi.com/api/deck/new/");
            WebRequest webRequest = WebRequest.Create(uri);
            WebResponse response = webRequest.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream());
            String responseData = streamReader.ReadToEnd();
            Juego oPartida = JsonConvert.DeserializeObject<Juego>(responseData);
            RunningData.Partida = oPartida;
        }



            public static void reshuffleCards(string code)
        {
            Uri uri = new Uri(@"https://deckofcardsapi.com/api/deck/"+code+"/shuffle/");
            WebRequest webRequest = WebRequest.Create(uri);
            WebResponse response = webRequest.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream());
            String responseData = streamReader.ReadToEnd();
            Juego oPartida = JsonConvert.DeserializeObject<Juego>(responseData);
            RunningData.Partida = oPartida;
            RunningData.Partida.Remaining = RunningData.Partida.Remaining - 4;
        }

    }
}
