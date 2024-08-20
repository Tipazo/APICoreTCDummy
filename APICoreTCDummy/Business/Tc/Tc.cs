using System.Data;
using APICoreTCDummy.Models;
using System.Text.RegularExpressions;
using System.Reflection;

namespace APICoreTCDummy.Business.Tc
{
    public class Tc
    {
        public Tc()
        {
        }

        public MTipoTarjeta verifica(string numeroTarjeta)
        {
            numeroTarjeta = numeroTarjeta.Replace(" ", "").Replace("-","");

            MTipoTarjeta mTipoTarjeta = new MTipoTarjeta();
            mTipoTarjeta.numeroTarjeta = numeroTarjeta;

            string visaPattern = @"^4[0-9]{12}(?:[0-9]{3})?$";
            string masterCardPattern = @"^5[0-5][0-9]{14}$";

            if (Regex.IsMatch(numeroTarjeta, visaPattern))
            {
                mTipoTarjeta.tipo = "Visa";
            }
            else if (Regex.IsMatch(numeroTarjeta, masterCardPattern))
            {
                mTipoTarjeta.tipo = "MasterCard";

            } else if (String.IsNullOrEmpty(numeroTarjeta))
            {
                throw new Exception("TarjetaNoValida");
            }
            else
            {
                throw new Exception("TarjetaNoValida");
            }

            return mTipoTarjeta;
        }

        public MSaldoTarjeta consultaSaldo(string numeroTarjeta, string tipoTarjeta)
        {
            Type type = Type.GetType($"APICoreTCDummy.Business.Tc.{tipoTarjeta}");

            if (string.IsNullOrEmpty(tipoTarjeta) || type == null)
            {
                throw new Exception(@$"Proveedor {tipoTarjeta} no configurado");
            }

            if (string.IsNullOrEmpty(numeroTarjeta))
            {
                throw new Exception(@$"numeroTarjeta requerido");
            }

            Object obj = Activator.CreateInstance(type);
            
            MethodInfo methodInfo = type.GetMethod("ConsultaSaldo");

            Object result = methodInfo.Invoke(obj, new object[] { numeroTarjeta });

            return (MSaldoTarjeta)result;
        }

        public Mtarjeta detalleTarjeta(string numeroTarjeta, string tipoTarjeta)
        {

            return new Mtarjeta();
        }

    }
}
