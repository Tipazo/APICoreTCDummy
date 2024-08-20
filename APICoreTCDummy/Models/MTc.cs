using System.Runtime.Intrinsics.Arm;

namespace APICoreTCDummy.Models
{
    public class MTipoTarjeta
    {
        public string numeroTarjeta { get; set; } = String.Empty;
        public string tipo { get; set; } = "proveedor";
    }

    public class MResponseTc
    {
        public Object data { get; set; } = new Object();
        public string tipo { get; set; } = "proveedor";
    }

    public class Mtarjeta
    {
        public string numeroTarjeta { get; set; } = String.Empty;
        public string nombres { get; set; } = String.Empty;
        public string apellidos { get; set; } = String.Empty;
        public string cvv { get; set; } = String.Empty;
        public string dpi { get; set; } = String.Empty;
        public string tipo { get; set; } = String.Empty;
        public string estado { get; set; } = String.Empty;
        public string fechaExpiracion { get; set; } = String.Empty;
        public string limiteCredito { get; set; } = String.Empty;

    }

    public class MSaldoTarjeta
    {
        public string numeroTarjeta { get; set; } = String.Empty;
        public string monto { get; set; } = String.Empty;
        public string fecha_pago { get; set; } = String.Empty;
        public string tipo { get; set; } = String.Empty;
    }

}
