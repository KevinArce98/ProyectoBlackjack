using Blackjack.Modelos;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
namespace Blackjack.Utils
{
    public class ApiNames
    {
        public static Result obtenerDealerOtro()
        {
            Uri uri = new Uri(@"https://randomuser.me/api/?inc=picture,name");
            WebRequest webRequest = WebRequest.Create(uri);
            WebResponse response = webRequest.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream());
            String responseData = streamReader.ReadToEnd();
            var outObject = JsonConvert.DeserializeObject<RootObjectDealerOtro>(responseData);
            Result oDealer = outObject.results[0];
            return oDealer;
        }
    }


}
