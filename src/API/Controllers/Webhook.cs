using API.DTO;
using API.Services;

using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Webhook : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Post([FromServices] WebsocketObterDados websocketObterDados, [FromBody] object? request)
        {
            var resultado = new Response();
            try
            {
                if (request is null)
                {
                    throw new ArgumentNullException("Payload é obrigatório");
                }

                websocketObterDados.Payload = request;

                resultado.Sucesso = true;
                return Ok(resultado);
            }
            catch (Exception e)
            {
                resultado.Mensagens.Add(e.Message);
                return BadRequest(resultado);
            }
        }
    }
}