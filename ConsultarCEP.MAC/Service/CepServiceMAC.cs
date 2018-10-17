using System;
using System.Net;
using ConsultarCEP.MAC.Service.Model;
using Newtonsoft.Json;

namespace ConsultarCEP.MAC.Service.Model
{
    public class CepServiceMAC
    {
        private static string AddressURL = "http://viacep.com.br/ws/{0}/json/";

        public static AddressCepMAC SearchAddressCEP(string cep)
        {
            string NewAddressURL = string.Format(AddressURL, cep);

            WebClient webClient = new WebClient();
            String Content = webClient.DownloadString(NewAddressURL);

            AddressCepMAC address = JsonConvert.DeserializeObject<AddressCepMAC>(Content);

            if (address.cep == null) { return null; }
            return address;
        }
    }
}
