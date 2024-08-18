using APICoreTCDummy.Models;
using Newtonsoft.Json;
using RestSharp;


namespace APICoreTCDummy.Business.Tc
{
    public class MasterCard: TcInterface
    {
        public MSaldoTarjeta ConsultaSaldo(string numeroTarjeta)
        {
            var apiUrl = Environment.GetEnvironmentVariable("API_MASTERCARD");
            MSaldoTarjeta tarjeta = new MSaldoTarjeta();

            try
            {
                var client = new RestClient(@$"{apiUrl}get_tc_bill?card_number={numeroTarjeta}&api-version=1.0");
                var request = new RestRequest();

                request.RequestFormat = DataFormat.Json;

                var response = client.ExecuteGet(request);

                if (response.IsSuccessful)
                {
                    if (response.Content == "" || response.Content == null)
                    {
                        throw new Exception("ErrorConsultaSaldoMasterCard");
                    }
                    else
                    {
                        MMasterCardSaldo saldo = JsonConvert.DeserializeObject<MMasterCardSaldo>(response.Content);

                        tarjeta.fecha_pago = saldo.data.pay_date;
                        tarjeta.monto = saldo.data.bill;
                        tarjeta.numeroTarjeta = numeroTarjeta;
                        tarjeta.tipo = "MasterCard";
                    }
                }
                else
                {
                    throw new Exception("ErrorConsultaSaldoMasterCard");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ErrorConsultaSaldoMasterCard");
            }

            return tarjeta;
        }

        public MResponseTc consultaXPdi(string dpi)
        {

            return new MResponseTc();
        }

        public decimal realizarpago(string numeroTarjeta, decimal monto)
        {
            return 00;
        }
        public decimal consultarPuntos(string numeroTarjeta)
        {
            return 00;
        }
    }
}
