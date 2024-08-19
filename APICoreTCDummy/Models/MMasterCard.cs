namespace APICoreTCDummy.Models
{
    public class MMasterCardSaldo
    {
        public int statusCode { get; set; }
        public Mdata data { get; set; }
        public Object errors { get; set; }
    }

    public class Mdata
    {
        public string card_number { get; set; }
        public string bill { get; set; }
        public string pay_date { get; set; }
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
