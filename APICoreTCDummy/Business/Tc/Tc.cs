using System.Data;
using APICoreTCDummy.Models;
using System.Text.RegularExpressions;

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

            if (Regex.IsMatch(numeroTarjeta.ToString(), visaPattern))
            {
                mTipoTarjeta.tipo = "Visa";
            }
            else if (Regex.IsMatch(numeroTarjeta.ToString(), masterCardPattern))
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

        public string ConsultarSaldo(string numeroTarjeta)
        {
            return "fdfd";
        }
    }
}
