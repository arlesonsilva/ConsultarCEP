using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using AppKit;
using ConsultarCEP.MAC.Service;
using ConsultarCEP.MAC.Service.Model;

namespace ConsultarCEP.MAC
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }



        partial void btnViewC(Foundation.NSObject sender)
        {
            String cep = textViewC.StringValue.Trim();
            if (isValidCEP(cep))
            {
                try
                {
                    AddressCepMAC address = CepServiceMAC.SearchAddressCEP(cep);
                    if (address != null)
                    {
                        lbViewC.StringValue = string.Format("Endereco: {0} \nBairro: {1} \nCidade: {2} \nEstado: {3}",
                                                     address.logradouro,
                                                     address.bairro,
                                                     address.localidade,
                                                     address.uf);
                    }
                    else
                    {
                        var alert = new NSAlert()
                        {
                            AlertStyle = NSAlertStyle.Informational,
                            InformativeText = "Endereço não encontrado para o cep informado: " + cep,
                            MessageText = "ERRO",
                        };
                        alert.RunModal();
                    }

                }
                catch (Exception e)
                {
                    var alert = new NSAlert()
                    {
                        AlertStyle = NSAlertStyle.Informational,
                        InformativeText = e.Message,
                        MessageText = "ERRO",
                    };
                    alert.RunModal();
                }

            }
        }

        private bool isValidCEP(String cep)
        {
            bool erro = true;
            if (cep.Length != 8)
            {
                var alert = new NSAlert()
                {
                    AlertStyle = NSAlertStyle.Informational,
                    InformativeText = "CEP deve conter 8 caracteres!",
                    MessageText = "ERRO",
                };
                alert.RunModal();
                erro = false;
            }

            int cepValid = 0;
            if (!int.TryParse(cep, out cepValid))
            {
                var alert = new NSAlert()
                {
                    AlertStyle = NSAlertStyle.Informational,
                    InformativeText = "CEP deve conter apenas números!",
                    MessageText = "ERRO",
                };
                alert.RunModal();
                erro = false;
            }

            return erro;
        }

    }
}
