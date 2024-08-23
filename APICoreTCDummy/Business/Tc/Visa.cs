using APICoreTCDummy.Models;
using Newtonsoft.Json;
using RestSharp;


namespace APICoreTCDummy.Business.Tc
{
    public class Visa : TcInterface
    {
        public MSaldoTarjeta ConsultaSaldo(string numeroTarjeta)
        {
            var apiUrl = "https://apivisadummy-production.up.railway.app";
            var client = new RestClient(apiUrl);
            var request = new RestRequest("/data/user-by-card", Method.Post);
            request.AddParameter("numero_tarjeta", numeroTarjeta);

            MSaldoTarjeta tarjeta = new MSaldoTarjeta();

            try
            {
                var response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    if (response.Content == "" || response.Content == null)
                    {
                        // se implementa LOG
                        throw new Exception("ErrorConsultaSaldoVisa");
                    }
                    else
                    {
                        VVisaCardSaldo saldo = JsonConvert.DeserializeObject<VVisaCardSaldo>(response.Content);

                        tarjeta.fecha_pago = saldo.fecha_expiracion;
                        tarjeta.monto = saldo.credito;
                        tarjeta.numeroTarjeta = numeroTarjeta;
                        tarjeta.tipo = "Visa";
                    }
                }
                else
                {
                    // se implementa LOG
                    throw new Exception("ErrorConsultaSaldoVisa");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción: " + ex.Message);
                return null;
            }

            return tarjeta;
        }




        public Mtarjeta DetalleTarjeta(string numeroTarjeta)
        {
            var apiUrl = "https://apivisadummy-production.up.railway.app";
            var client = new RestClient(apiUrl);
            var request = new RestRequest("/data/user-by-card", Method.Post);
            request.AddParameter("numero_tarjeta", numeroTarjeta);

            Mtarjeta tarjeta = new Mtarjeta();

            try
            {
                var response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    if (response.Content == "" || response.Content == null)
                    {
                        // se implementa LOG
                        throw new Exception("ErrorConsultaSaldoMasterCard");
                    }
                    else
                    {
                        VVisaCardSaldo detalle = JsonConvert.DeserializeObject<VVisaCardSaldo>(response.Content);

                        tarjeta.numeroTarjeta = detalle.numero_tarjeta;
                        tarjeta.nombres = detalle.nombre;
                        tarjeta.apellidos = detalle.apellido;
                        tarjeta.cvv = detalle.cvv;
                        tarjeta.dpi = detalle.dpi;
                        tarjeta.estado = detalle.estado;
                        tarjeta.fechaExpiracion = detalle.fecha_expiracion;
                        tarjeta.limiteCredito = detalle.credito;
                        tarjeta.tipo = "Visa";
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
                Console.WriteLine("Excepción: " + ex.Message);
                return null;
            }

            return tarjeta;
        }

        public MPagoRealizado RealizarPago(string numeroTarjeta)
        {
            return new MPagoRealizado();
        }
    }
}
