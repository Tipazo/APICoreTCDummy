namespace APICoreTCDummy.Business.Tc
{
    public interface TcInterface
    {
        public decimal consultaSaldo(string numeroTarjeta);
        public decimal realizarpago(string numeroTarjeta, decimal monto);
        public decimal consultarPuntos(string numeroTarjeta);
    }
}
