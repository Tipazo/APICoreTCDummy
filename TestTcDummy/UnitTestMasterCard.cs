using APICoreTCDummy.Business.Tc;
using APICoreTCDummy.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestTcDummy.Test
{
    [TestClass]
    public class UnitTestMasterCard
    {
        // Test API PROVEEDOR
        [TestMethod]
        public void TestMethodValidaApiStatus200ConsultaSaldo()
        {
            //arrange            
            var apiUrl = "http://10.50.51.110:9090/api/MasterCard/";
            string numeroTarjeta = "5474388764954066";

            var client = new RestClient(@$"{apiUrl}get_tc_bill?card_number={numeroTarjeta}&api-version=1.0");
            var request = new RestRequest();
            request.RequestFormat = DataFormat.Json;
            var response = client.ExecuteGet(request);

            //act
            MMasterCardSaldo expected = JsonConvert.DeserializeObject<MMasterCardSaldo>(response.Content);

            //assert
            Assert.AreEqual(expected.statusCode, 200);
            Assert.AreEqual(expected.data.card_number, numeroTarjeta);
        }

        [TestMethod]
        public void TestMethodValidaApiStatusCode404ConsultaSaldo()
        {
            //arrange            
            var apiUrl = "http://10.50.51.110:9090/api/MasterCard/";
            string numeroTarjeta = "hola";

            var client = new RestClient(@$"{apiUrl}get_tc_bill?card_number={numeroTarjeta}&api-version=1.0");
            var request = new RestRequest();
            request.RequestFormat = DataFormat.Json;
            var response = client.ExecuteGet(request);

            //act
            MMasterCardSaldo expected = JsonConvert.DeserializeObject<MMasterCardSaldo>(response.Content);

            //assert
            Assert.AreEqual(expected.statusCode, 404);
            Assert.AreEqual(expected.data, null);
        }


        [TestMethod]
        public void TestMethodValidaApiStatus400BadRequestConsultaSaldo()
        {
            //arrange            
            var apiUrl = "http://10.50.51.110:9090/api/MasterCard/";
            string numeroTarjeta = string.Empty;

            var client = new RestClient(@$"{apiUrl}get_tc_bill?card_number={numeroTarjeta}&api-version=1.0");
            var request = new RestRequest();
            request.RequestFormat = DataFormat.Json;
            var response = client.ExecuteGet(request);

            //act
            MBadRequestCardNumber expected = JsonConvert.DeserializeObject<MBadRequestCardNumber>(response.Content);

            //assert
            Assert.AreEqual(expected.status, 400);
            Assert.AreEqual(expected.title, "One or more validation errors occurred.");
        }


        [TestMethod]
        public void TestMethodValidaApiStatus200DetalleTarjeta()
        {
            //arrange            
            var apiUrl = "http://10.50.51.110:9090/api/MasterCard/";
            string numeroTarjeta = "5474388764954066";

            var client = new RestClient(@$"{apiUrl}get_tc_data?card_number={numeroTarjeta}&api-version=1.0");
            var request = new RestRequest();
            request.RequestFormat = DataFormat.Json;
            var response = client.ExecuteGet(request);

            //act
            MMasterDetalleTarjeta expected = JsonConvert.DeserializeObject<MMasterDetalleTarjeta>(response.Content);
            bool expirationDateExpected = Regex.IsMatch(expected.data.expiration_date, "^2\\d{2,4}-\\d{1,2}");
            bool cvvExpected = Regex.IsMatch(expected.data.expiration_date, "[0-9]{3,4}");

            //assert
            Assert.AreEqual(expected.statusCode, 200);
            Assert.AreEqual(expected.data.card_number, numeroTarjeta);
            Assert.AreEqual(cvvExpected, true);
            Assert.AreEqual(expirationDateExpected, true);
        }


        // Test CONSULTA SALDO

        [TestMethod]
        public void TestMethodConsultaSaldoExceptionValidaNumeroTarjeta()
        {
            //arrange
            MasterCard masterCard = new MasterCard();
            string numeroTarjeta = string.Empty;

            string expected = "ErrorConsultaSaldoMasterCard";

            //act
            Exception exception = Assert.ThrowsException<Exception>(() => masterCard.ConsultaSaldo(numeroTarjeta));

            //assert
            Assert.AreEqual(expected, exception.Message);
        }

        [TestMethod]
        public void TestMethodConsultaSaldoOK()
        {
            //arrange            
            MasterCard masterCard = new MasterCard();
            string numeroTarjeta = "5474388764954066";

            //act
            MSaldoTarjeta expected =  masterCard.ConsultaSaldo(numeroTarjeta);

            //assert
            Assert.AreEqual(expected.numeroTarjeta, numeroTarjeta);
            Assert.AreEqual(expected.tipo , "MasterCard");
        }

        [TestMethod]
        public void TestMethodDetalleTarjetaExceptionValidaNumeroTarjeta()
        {
            //arrange
            MasterCard masterCard = new MasterCard();
            string numeroTarjeta = string.Empty;

            string expected = "ErrorConsultaDetalleMasterCard";

            //act
            Exception exception = Assert.ThrowsException<Exception>(() => masterCard.DetalleTarjeta(numeroTarjeta));

            //assert
            Assert.AreEqual(expected, exception.Message);
        }

        [TestMethod]
        public void TestMethodDetalleTarjetaOK()
        {
            //arrange            
            MasterCard masterCard = new MasterCard();
            string numeroTarjeta = "5474388764954066";

            //act
            Mtarjeta expected = masterCard.DetalleTarjeta(numeroTarjeta);

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
