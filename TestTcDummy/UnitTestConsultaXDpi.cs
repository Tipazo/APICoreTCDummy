using APICoreTCDummy.Business.Tc;
using APICoreTCDummy.Models;

namespace TestTcDummy.Test
{
    [TestClass]
    public class UnitTestConsultaXDpi
    {
        [TestMethod]
        public void TestMethodThrowsExceptionValidaQueNoEsDPI()
        {
            Tc tarjeta = new Tc();
            string dpi = "1708";
            string expected = "TarjetaNoValida";

            //act
            Exception exception = Assert.ThrowsException<Exception>(() => tarjeta.DetalleXDpi(dpi));

            //assert
            Assert.AreEqual(expected, exception.Message);
        }

        [TestMethod]
        public void TestMethodThrowsExceptionValidaValorNulo()
        {
            Tc tarjeta = new Tc();
            string dpi = string.Empty;
            string expected = "TarjetaNoValida";

            //act
            Exception exception = Assert.ThrowsException<Exception>(() => tarjeta.DetalleXDpi(dpi));

            //assert
            Assert.AreEqual(expected, exception.Message);
        }
    }
}
