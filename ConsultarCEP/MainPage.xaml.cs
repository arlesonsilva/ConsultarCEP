using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ConsultarCEP.Service;
using ConsultarCEP.Service.Model;

namespace ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            btBuscar.Clicked += SearchCEP;
        }

        private void SearchCEP(object sender, EventArgs args) 
        {
            String cep = lbCep.Text.Trim();
            if (isValidCEP(cep)) 
            {
                try
                {
                    Address address = CepService.SearchAddressCEP(cep);
                    if (address != null) 
                    {
                        lbResultado.Text = string.Format("Endereco: {0} \nBairro: {1} \nCidade: {2} \nEstado: {3}",
                                                     address.logradouro,
                                                     address.bairro,
                                                     address.localidade,
                                                     address.uf);
                    }else
                    {
                        DisplayAlert("ERRO", "Endereço não encontrado para o cep informado: " + cep, "Ok");
                    }

                } catch (Exception e)
                {
                    DisplayAlert("ERRO", e.Message, "Ok");
                }

            }
        }

        private bool isValidCEP(String cep)
        {
            bool erro = true;
            if (cep.Length != 8)
            {
                DisplayAlert("ERRO","CEP deve conter 8 caracteres!","Ok");
                erro = false;
            }

            int cepValid = 0;
            if (!int.TryParse(cep, out cepValid))
            {
                DisplayAlert("ERRO", "CEP deve conter apenas números!", "Ok");
                erro = false;
            }

            return erro;
        }
    }
}
