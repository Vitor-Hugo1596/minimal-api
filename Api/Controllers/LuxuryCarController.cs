using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Dominio.Entidades;

namespace mininal_api.Controllers
{ [ApiController]
    [Route("api/[controller]")]
    public class LuxuryCarController : ControllerBase
    {
        private static List<Veiculo> luxuryCars = new List<Veiculo>();

        [HttpPost("add")]
        public IActionResult AddCar([FromBody] Veiculo car)
        {
            try
            {
                if (car.Valor < 100000M) // exemplo: só carros acima de 100 mil
                    return BadRequest("Somente carros de luxo podem ser adicionados.");

                luxuryCars.Add(car);
                return Ok(new { message = "Carro de luxo adicionado com sucesso!", car });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro inesperado: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(luxuryCars);
        }
    }
}