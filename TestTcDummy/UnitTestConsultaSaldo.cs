using APICoreTCDummy.Business.Tc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTcDummy.Test
{
    [TestClass]
    public class UnitTestConsultaSaldo
    {
        [TestMethod]
        public void TestMethodThrowsExceptionValidaExistenciaProveedor()
        {
            //arrange
            Tc tarjeta = new Tc();
            string tipo = "Visa";
            string numeroTarjeta = "4915874449533417";

            //act
            var respuesta = tarjeta.consultaSaldo(numeroTarjeta, tipo);

            //assert
            Assert.IsNotNull(respuesta);
        }

        [TestMethod]
        public void TestMethodThrowsExceptionValidaTarjetaEmpty()
        {
            //arrange
            Tc tarjeta = new Tc();
            string tipo = "MasterCard";
            string numeroTarjeta = string.Empty;
            string expected = "numeroTarjeta requerido";

            //act
            Exception exception = Assert.ThrowsException<Exception>(() => tarjeta.consultaSaldo(numeroTarjeta, tipo));

            //assert
            Assert.AreEqual(expected, exception.Message);
        }

    }
}
