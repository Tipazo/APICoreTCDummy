using Microsoft.AspNetCore.Mvc;
using System.Data;
using APICoreTCDummy.Models;
using APICoreTCDummy.Business.Tc;

namespace APICoreTCDummy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TcController : Controller
    {
        [HttpPost]
        [Route("consultaSaldo")]
        public ActionResult consultaSaldo([FromQuery] MNumeroTarjeta filters)
        {
            APIresponse respose = new APIresponse();
            try
            {
                Tc tarjeta = new Tc();

                MTipoTarjeta verifica = tarjeta.verifica(filters.numeroTarjeta);

                MSaldoTarjeta saldo = tarjeta.consultaSaldo(filters.numeroTarjeta, verifica.tipo);

                respose.result = saldo;
            }
            catch (Exception ex)
            {
                respose.error.code = 2;
                respose.error.message = ex.Message;
            }

            return Ok(respose);
        }

        [HttpPost]
        [Route("detalleTarjeta/numeroTarjeta")]
        public ActionResult detallexNumeroTarjeta([FromQuery] MNumeroTarjeta filters)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                
            }

            return Ok("Holamundo");
        }

        [HttpPost]
        [Route("detalleTarjeta/dpi")]
        public ActionResult detallexDpi([FromQuery] MNumeroDpi filters)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                
            }

            return Ok("Holamundo");
        }

    }
}
