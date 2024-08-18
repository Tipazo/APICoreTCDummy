using APICoreTCDummy.Models;

namespace APICoreTCDummy.Business.Tc
{
    public interface TcInterface
    {
        public MResponseTc consultaXPdi(string dpi);

        public MSaldoTarjeta ConsultaSaldo(string numeroTarjeta);
        public decimal realizarpago(string numeroTarjeta, decimal monto);
        public decimal consultarPuntos(string numeroTarjeta);
    }
}
