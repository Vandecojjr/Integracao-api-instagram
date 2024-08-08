using Instagram.Integracao.Handlers;
using Instagram.Integracao.Handlers.Contracts;
using Instagram.Integracao.Models;
using Instagram.Integracao.Models.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Integracao.Controllers
{
    [ApiController]
    [Route("/v1/mensagem")]
    public class MensagemController : ControllerBase
    {
        private readonly IHandler<CriarBuscaDeMensagem> _handlerBuscar;

        public MensagemController(IHandler<CriarBuscaDeMensagem> handler)
        {
            _handlerBuscar = handler;
        }


        [HttpGet]
        public async Task<ActionResult<RetornoGenericoModel>> Get([FromQuery] string? UsuarioId)
        {
            var result = await _handlerBuscar.Handle(new CriarBuscaDeMensagem { idDoUsuario = UsuarioId }) as RetornoGenericoModel;
            if (!result.Sucesso)
                return BadRequest(result);
            return Ok(result);

        }
    }
}