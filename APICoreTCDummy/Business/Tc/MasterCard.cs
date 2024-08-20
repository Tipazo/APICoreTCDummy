using APICoreTCDummy.Models;
using Newtonsoft.Json;
using RestSharp;


namespace APICoreTCDummy.Business.Tc
{
    public class MasterCard: TcInterface
    {
        public MSaldoTarjeta ConsultaSaldo(string numeroTarjeta)
        {
            //var apiUrl = Environment.GetEnvironmentVariable("API_MASTERCARD");
            var apiUrl = "http://10.50.51.110:9090/api/MasterCard/";
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
                        // se implementa LOG
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
                    // se implementa LOG
                    throw new Exception("ErrorConsultaSaldoMasterCard");
                }
            }
            catch (Exception ex)
            {
                // se implementa LOG 
                throw new Exception("ErrorConsultaSaldoMasterCard");
            }

            return tarjeta;
        }

        public Mtarjeta DetalleTarjeta(string numeroTarjeta)
        {
            //var apiUrl = Environment.GetEnvironmentVariable("API_MASTERCARD");
            var apiUrl = "http://10.50.51.110:9090/api/MasterCard/";
            Mtarjeta tarjeta = new Mtarjeta();

            try
            {
                var client = new RestClient(@$"{apiUrl}get_tc_data?card_number={numeroTarjeta}&api-version=1.0");
                var request = new RestRequest();

                request.RequestFormat = DataFormat.Json;

                var response = client.ExecuteGet(request);

                if (response.IsSuccessful)
                {
                    if (response.Content == "" || response.Content == null)
                    {
                        // se implementa LOG
                        throw new Exception("ErrorConsultaDetalleMasterCard");
                    }
                    else
                    {
                        MMasterDetalleTarjeta detalle = JsonConvert.DeserializeObject<MMasterDetalleTarjeta>(response.Content);

                        tarjeta.numeroTarjeta = detalle.data.card_number;
                        tarjeta.nombres = detalle.data.first_name;
                        tarjeta.apellidos = detalle.data.last_name;
                        tarjeta.cvv = detalle.data.cvv;
                        tarjeta.fechaExpiracion = detalle.data.expiration_date;
                        tarjeta.estado = detalle.data.state;
                        tarjeta.limiteCredito = detalle.data.credit;
                        tarjeta.dpi = detalle.data.dpi.ToString();
                        tarjeta.tipo = "MasterCard";
                    }
                }
                else
                {
                    // se implementa LOG
                    throw new Exception("ErrorConsultaDetalleMasterCard");
                }
            }
            catch (Exception ex)
            {
                // se implementa LOG 
                throw new Exception("ErrorConsultaDetalleMasterCard");
            }

            return tarjeta;
        }

        public MPagoRealizado RealizarPago(string numeroTarjeta)
        {
            return new MPagoRealizado();
        }
    }
}
