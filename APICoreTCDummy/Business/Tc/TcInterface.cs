using APICoreTCDummy.Models;

namespace APICoreTCDummy.Business.Tc
{
    public interface TcInterface
    {
        
        public MSaldoTarjeta ConsultaSaldo(string numeroTarjeta);
        public Mtarjeta DetalleTarjeta(string numeroTarjeta);
        public MPagoRealizado RealizarPago(string numeroTarjeta);

    }
}
