using ApiManejoErrores.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManejoErrores.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        private ECode CallService()
        {
            ECode code = new ECode();
            code.code = "400";
            code.analyticsCode = "ERAA563";
            return code;
        }
 
        [HttpGet]
        public ActionResult<string> Get()
        {
            try
            {

                var code = CallService();
                var resp = EResolver.GetStatusCode(code);
                if (resp.httpstatuscode == 200)
                    return Ok("Accion exitosa"); //El Ok es por si necesitamos devolver algo. Sino se puede devolver el StatusCode con 200.
                else
                {
                    var resultado = StatusCode(resp.httpstatuscode, resp.descripcion);
                    //Loguear error
                    return resultado; 
                }
            }
            catch(Exception e)
            {
                //Loguear error
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }



    }
}
