using System.ComponentModel.DataAnnotations;

namespace APICoreTCDummy.Models
{
    public class MNumeroTarjeta
    {
        //[Required]
        public string numeroTarjeta { get; set; } = string.Empty;
    }

    public class MNumeroDpi
    {
        //[Required]
        public string dpi { get; set; } = string.Empty;
    }

}
