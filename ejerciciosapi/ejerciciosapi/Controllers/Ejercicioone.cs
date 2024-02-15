using Microsoft.AspNetCore.Mvc;
namespace ejerciciosapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Ejercicioone : ControllerBase
    {
        private bool EsNumeroPar(long respuesta)
        {
            return respuesta % 2 == 0;
        }

        [HttpGet("{numero}")]
        public ActionResult<string> Get(string numero)
        {
            if (long.TryParse(numero, out long respuesta))
            {
                if (EsNumeroPar(respuesta))
                {
                    return $"{respuesta} es un número par.";
                }
                else
                {
                    return $"{respuesta} es un número impar.";
                }
            }
            else
            {
                return $"{numero} no es un número válido (Recuerda no ingresar signos, letras, simbolos, iconos, números decimales).";
            }
        }
    }
}
