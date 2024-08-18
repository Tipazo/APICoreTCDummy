namespace APICoreTCDummy.Models
{
    public class APIresponse
    {
        public Object result { get; set; }
        public Metrics metrics { get; set; } = new Metrics();
        public Error error { get; set; } = new Error();
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
