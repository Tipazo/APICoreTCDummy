using System.ComponentModel.DataAnnotations;

namespace APICoreTCDummy.Models
{
    public class MNumeroTarjeta
    {
        //[Required]
        public string numeroTarjeta { get; set; } = string.Empty;
    }

    public class MPagoRealizado
    {
        //[Required]
        public string numeroTarjeta { get; set; } = string.Empty;
        public string monto { get; set; } = string.Empty;
        public string moneda { get; set; } = string.Empty;
        public string mensage { get; set; } = "Pago";
    }

    public class MRealizarPago
    {
        //[Required]
        public string numeroTarjeta { get; set; } = string.Empty;
        public string monto { get; set; } = string.Empty;
        public string moneda { get; set; } = string.Empty;        
    }

}
