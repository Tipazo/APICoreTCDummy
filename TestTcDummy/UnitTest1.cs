using APICoreTCDummy.Business.Tc;
using APICoreTCDummy.Models;

namespace TestTcDummy.Test
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethodThrowsExceptionValidaVaDPI()
        {
            //arrange
            Tc tarjeta = new Tc();
            string numeroTarjeta = "1708 54167 1401";
            string expected = "TarjetaNoValida";

            //act
            Exception exception = Assert.ThrowsException<Exception>(() => tarjeta.verifica(numeroTarjeta));

            //assert
            Assert.AreEqual(expected, exception.Message);
        }

        [TestMethod]
        public void TestMethodThrowsExceptionValidaValorEmpty()
        {
            //arrange
            Tc tarjeta = new Tc();
            string numeroTarjeta = string.Empty;
            string expected = "TarjetaNoValida";

            //act
            Exception exception = Assert.ThrowsException<Exception>(() => tarjeta.verifica(numeroTarjeta));

            //assert
            Assert.AreEqual(expected, exception.Message);
        }

        [TestMethod]
        public void TestMethodValidaTarejtaVisa()
        {
            //arrange
            Tc tarjeta = new Tc();
            string numeroTarjeta = "4334884599002300";
            string expected = "Visa";
            
            //act
            MTipoTarjeta result = tarjeta.verifica(numeroTarjeta);

            //assert
            Assert.AreEqual(expected, result.tipo);
        }

        [TestMethod]
        public void TestMethodValidaTarejtaTest()
        {
            //arrange
            Tc tarjeta = new Tc();
            //string numeroTarjeta = "4334884599002300";
            string numeroTarjeta = "4444444444444444";
            string expected = "Visa";

            //act
            MTipoTarjeta result = tarjeta.verifica(numeroTarjeta);

            //assert
            Assert.AreEqual(expected, result.tipo);
        }

    }
}