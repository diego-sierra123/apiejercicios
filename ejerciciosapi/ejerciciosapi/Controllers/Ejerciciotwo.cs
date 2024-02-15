using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace ejerciciosapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Ejerciciotwo : ControllerBase
    {
        private double promedio;
        private double CalcularPromedio(long num1, long num2, long num3)
        {
            return (num1 + num2 + num3) / 3.0;
        }

        [HttpPost("datos")]
        public IActionResult Post([Required] string num1, [Required] string num2, [Required] string num3)
        {
            if (long.TryParse(num1, out long numero1) && long.TryParse(num2, out long numero2) && long.TryParse(num3, out long numero3))
            {
                if (numero1 > 0 && numero2 > 0 && numero3 > 0)
                {
                    promedio = CalcularPromedio(numero1, numero2, numero3);
                    var promedioRound = Math.Round(promedio, 2);
                    if (promedioRound == promedio)
                    {
                        var resultado = new
                        {
                            Promedio = promedioRound,
                            Mensaje = "El promedio es un número entero."
                        };
                        return Ok(resultado);
                    }
                    else
                    {
                        var resultado = new
                        {
                            Promedio = promedioRound,
                            Mensaje = "El promedio es un número decimal."
                        };
                        return Ok(resultado);
                    }
                }
                else
                {
                    var resultado = new
                    {
                        Promedio = "Error",
                        Mensaje = "Por favor, ingrese solo números enteros positivos y no números negativos o 0."
                    };
                    return Ok(resultado);
                }
            }
            else
            {
                var resultado = new
                {
                    Promedio = "Error",
                    Mensaje = "Por favor, ingrese solo números enteros positivos y no símbolos, iconos, letras, números decimales, etc."
                };
                return Ok(resultado);
            }
        }
    }
}
