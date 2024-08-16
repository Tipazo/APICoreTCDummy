using Microsoft.AspNetCore.Mvc;
using System.Data;
using APICoreTCDummy.Models;

namespace APICoreTCDummy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TcController : Controller
    {
        [HttpGet]
        [Route("consultaSaldo")]
        public ActionResult consultaSaldo([FromBody] MTcValidation filters)
        {
            try
            {
                //return $"total: {total}";
            }
            catch (Exception ex)
            {
                //return ex.Message;
            }

            return Ok("Holamundo");
        }

    }
}
