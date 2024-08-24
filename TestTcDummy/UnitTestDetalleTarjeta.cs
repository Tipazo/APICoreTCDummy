using APICoreTCDummy.Business.Tc;
using APICoreTCDummy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestTcDummy.Test
{
    [TestClass]
    public class UnitTestDetalleTarjeta
    {
        [TestMethod]
        public void TestMethodDetalleTarjetaExceptionValidaNumeroTarjetaVaciaMasterCard()
        {
            //arrange
            Tc tc = new Tc();

            string numeroTarjeta = string.Empty;
            string expected = "numeroTarjeta requerido";

            //act
            Exception exception = Assert.ThrowsException<Exception>(() => tc.detalleTarjeta(numeroTarjeta, "MasterCard"));

            //assert
            Assert.AreEqual(expected, exception.Message);
        }

        [TestMethod]
        public void TestMethodDetalleTarjetaExceptionValidaNumeroTarjetaMaster()
        {
            //arrange
            Tc tc = new Tc();

            string numeroTarjeta = "5474388764954888";
            string expected = "Numero de tarjeta 5474388764954888 - MasterCard no tiene datos";

            //act
            Exception exception = Assert.ThrowsException<Exception>(() => tc.detalleTarjeta(numeroTarjeta, "MasterCard"));

            //assert
            Assert.AreEqual(expected, exception.Message);
        }

        [TestMethod]
        public void TestMethodDetalleTarjetaOKMasterCard()
        {
            //arrange            
            Tc tc = new Tc();
            string numeroTarjeta = "5474388764954066";

            //act
            Mtarjeta expected = tc.detalleTarjeta(numeroTarjeta, "MasterCard");

            bool expirationDateExpected = Regex.IsMatch(expected.fechaExpiracion, "^2\\d{2,4}-\\d{1,2}");
            bool cvvExpected = Regex.IsMatch(expected.cvv, "[0-9]{3,4}");

            //assert            
            Assert.AreEqual(expected.numeroTarjeta, numeroTarjeta);
            Assert.AreEqual(cvvExpected, true);
            Assert.AreEqual(expirationDateExpected, true);
            Assert.AreEqual(expected.tipo, "MasterCard");
        }
    }
}
