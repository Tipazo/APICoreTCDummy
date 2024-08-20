namespace APICoreTCDummy.Models
{
    public class MMasterCardSaldo
    {
        public int statusCode { get; set; }
        public MdataSaldo data { get; set; }
        public Object errors { get; set; }
    }

    public class MdataSaldo
    {
        public string card_number { get; set; }
        public string bill { get; set; }
        public string pay_date { get; set; }
    }

    public class MMasterDetalleTarjeta
    {
        public int statusCode { get; set; }
        public MdataDetalleTarjeta data { get; set; }
        public Object errors { get; set; }
    }

    public class MdataDetalleTarjeta
    {
        public string card_number { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string cvv { get; set; }
        public string credit { get; set; }
        public string expiration_date { get; set; }
        public long dpi { get; set; }
        public bool state { get; set; }
    }


    // Validaciones API
    public class MBadRequestCardNumber
    {
        public int status { get; set; }
        public string title { get; set; } = string.Empty;
        public Merrors errors { get; set; } = new Merrors();
    }

    public class Merrors
    {
        public string[] card_number { get; set; }
    }
}
