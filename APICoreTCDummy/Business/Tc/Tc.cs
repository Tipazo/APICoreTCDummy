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
            string masterCardPattern = @"^5[1-5][0-9]{14}$";

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
            
            Object obj = Activator.CreateInstance(type);
            
            MethodInfo methodInfo = type.GetMethod("ConsultaSaldo");

            Object result = methodInfo.Invoke(obj, new object[] { numeroTarjeta });

            return (MSaldoTarjeta)result;
        }

        public MResponseTc DetalleXDpi(string dpi)
        {
            string dpiPattern = "^[0-9]{13}$";

            if (String.IsNullOrEmpty(dpi) || !Regex.IsMatch(dpi, dpiPattern))
            {
                throw new Exception("TarjetaNoValida");
            }

            //Type type = Type.GetType($"APICoreTCDummy.Models.Tc.{tipoTarjeta}");

            // Create an instance of that type
            //Object obj = Activator.CreateInstance(type);

            // Retrieve the method you are looking for
            //MethodInfo methodInfo = type.GetMethod("saldo");

            // Invoke thei method on the instance we created above
            //Object i = methodInfo.Invoke(obj, new object[] { numeroTarjeta });

            //return Convert.ToInt64(i);

            return new MResponseTc();
        }
        
    }
}
