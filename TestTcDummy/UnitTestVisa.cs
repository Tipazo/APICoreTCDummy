using APICoreTCDummy.Business.Tc;
using APICoreTCDummy.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestTcDummy.Test
{
    [TestClass]
    public class UnitTestVisa
    {
        // Test API PROVEEDOR
        [TestMethod]
        public void TestMethodValidaApiStatus200ConsultaSaldo()
        {
            //arrange            
            string numeroTarjeta = "4929393917173462";

            var apiUrl = "https://apivisadummy-production.up.railway.app";
            var client = new RestClient(apiUrl);
            var request = new RestRequest("/data/user-by-card", Method.Post);
            request.AddParameter("numero_tarjeta", numeroTarjeta);
            var response = client.Execute(request);

            //act
            VVisaCardSaldo expected = JsonConvert.DeserializeObject<VVisaCardSaldo>(response.Content);

            //assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(expected.numero_tarjeta, numeroTarjeta);
        }

        [TestMethod]
        public void TestMethodValidaApiStatusCode404ConsultaSaldo()
        {
            //arrange            
            string numeroTarjeta = "hola";

            var apiUrl = "https://apivisadummy-production.up.railway.app";
            var client = new RestClient(apiUrl);
            var request = new RestRequest("/data/user-by-card", Method.Post);
            request.AddParameter("numero_tarjeta", numeroTarjeta);

            // Act
            var response = client.Execute(request);

            //act
            var jsonResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
            string actualMessage = jsonResponse.message;
            string expectedMessage = "User not found";
            Assert.AreEqual(expectedMessage, actualMessage);

            VVisaCardSaldo expected = JsonConvert.DeserializeObject<VVisaCardSaldo>(response.Content);
            Assert.IsNull(expected.numero_tarjeta, null);
        }


        [TestMethod]
        public void TestMethodValidaApiStatus400BadRequestConsultaSaldo()
        {
            //arrange           
            string numeroTarjeta = string.Empty;

            var apiUrl = "https://apivisadummy-production.up.railway.app";
            var client = new RestClient(apiUrl);
            var request = new RestRequest("/data/user-by-card", Method.Post);
            request.AddParameter("numero_tarjeta", numeroTarjeta);
            var response = client.Execute(request);

            //act
            MBadRequestCardNumber expected = JsonConvert.DeserializeObject<MBadRequestCardNumber>(response.Content);

            //assert
            var jsonResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
            string actualMessage = jsonResponse.message;
            string expectedMessage = "User not found";
            Assert.AreEqual(expectedMessage, actualMessage);

            VVisaCardSaldo respuesta = JsonConvert.DeserializeObject<VVisaCardSaldo>(response.Content);
            Assert.IsNull(respuesta.numero_tarjeta, null);
        }


        [TestMethod]
        public void TestMethodValidaApiStatus200DetalleTarjeta()
        {
            //arrange          
            string numeroTarjeta = "4929393917173462";

            var apiUrl = "https://apivisadummy-production.up.railway.app";
            var client = new RestClient(apiUrl);
            var request = new RestRequest("/data/user-by-card", Method.Post);
            request.AddParameter("numero_tarjeta", numeroTarjeta);
            var response = client.Execute(request);

            //act
            VVisaCardSaldo expected = JsonConvert.DeserializeObject<VVisaCardSaldo>(response.Content);
            bool expirationDateExpected = Regex.IsMatch(expected.fecha_expiracion, "^2\\d{2,4}-\\d{1,2}");
            bool cvvExpected = Regex.IsMatch(expected.fecha_expiracion, "[0-9]{3,4}");

            //assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(expected.numero_tarjeta, numeroTarjeta);
            Assert.AreEqual(cvvExpected, true);
            Assert.AreEqual(expirationDateExpected, true);
        }


        // Test CONSULTA SALDO

        [TestMethod]
        public void TestMethodConsultaSaldoExceptionValidaNumeroTarjeta()
        {
            //arrange
            Visa visa = new Visa();
            string numeroTarjeta = string.Empty;

            string expected = "ErrorConsultaSaldo";

            //act
            var respuesta = visa.ConsultaSaldo(numeroTarjeta);

            //assert
            Assert.AreEqual(respuesta.numeroTarjeta, "");
        }

        [TestMethod]
        public void TestMethodConsultaSaldoOK()
        {
            //arrange            
            Visa visa = new Visa();
            string numeroTarjeta = "4556737586899855";

            //act
            MSaldoTarjeta expected = visa.ConsultaSaldo(numeroTarjeta);

            //assert
            Assert.AreEqual(expected.numeroTarjeta, numeroTarjeta);
            Assert.AreEqual(expected.tipo, "Visa");
        }

        [TestMethod]
        public void TestMethodDetalleTarjetaExceptionValidaNumeroTarjeta()
        {
            //arrange
            Visa visa = new Visa();
            string numeroTarjeta = string.Empty;

            string expected = "ErrorConsultaDetalleVisa";

            //act
            Mtarjeta respuesta = visa.DetalleTarjeta(numeroTarjeta);

            //assert
            Assert.AreEqual(respuesta.numeroTarjeta, null);
        }

        [TestMethod]
        public void TestMethodDetalleTarjetaOK()
        {
            //arrange            
            Visa visa = new Visa();
            string numeroTarjeta = "4929393917173462";

            //act
            Mtarjeta expected = visa.DetalleTarjeta(numeroTarjeta);

            bool expirationDateExpected = Regex.IsMatch(expected.fechaExpiracion, "^2\\d{2,4}-\\d{1,2}");
            bool cvvExpected = Regex.IsMatch(expected.cvv, "[0-9]{3,4}");

            //assert            
            Assert.AreEqual(expected.numeroTarjeta, numeroTarjeta);
            Assert.AreEqual(cvvExpected, true);
            Assert.AreEqual(expirationDateExpected, true);
            Assert.AreEqual(expected.tipo, "Visa");
        }

    }
}
