namespace APICoreTCDummy.Models
{
    public class APIresponse
    {
        public Data result { get; set; } = new Data();
        public Metrics metrics { get; set; } = new Metrics();
        public Error error { get; set; } = new Error();
    }

    public class Data
    {
        public Object data { get; set; } = new Object();
        public string tipoTarjeta { get; set; } = null;

    }

    public class Metrics
    {
        public DateTime startDate { get; set; } = DateTime.Now;
        public DateTime endDate { get; set; } = DateTime.Now;
        public string resultTime { get; set; } = null;
    }

    public class Error
    {
        public int code { get; set; } = 0;
        public string message { get; set; } = "Proceso finalizado con exito";
    }

}
