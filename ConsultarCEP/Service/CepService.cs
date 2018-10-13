using System;
using System.Net;
using ConsultarCEP.Service.Model;
using Newtonsoft.Json;

namespace ConsultarCEP.Service
{
    public class CepService
    {
        private static string AddressURL = "http://viacep.com.br/ws/{0}/json/";

        public static Address SearchAddressCEP(string cep) 
        {
            string NewAddressURL = string.Format(AddressURL, cep);

            WebClient webClient = new WebClient();
            String Content = webClient.DownloadString(NewAddressURL);

            Address address = JsonConvert.DeserializeObject<Address>(Content);

            return address;
        }
    }
}
