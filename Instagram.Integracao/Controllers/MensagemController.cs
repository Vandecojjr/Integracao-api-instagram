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
        private readonly IHandler<CriarpublicacaoDeMensagem> _handlerEnviar;

        public MensagemController(IHandler<CriarBuscaDeMensagem> handler, IHandler<CriarpublicacaoDeMensagem> handlerEnviar)
        {
            _handlerBuscar = handler;
            _handlerEnviar = handlerEnviar;
        }


        [HttpGet]
        public async Task<ActionResult<RetornoGenericoModel>> Get([FromQuery] string? UsuarioId)
        {
            var result = await _handlerBuscar.Handle(new CriarBuscaDeMensagem { idDoUsuario = UsuarioId }) as RetornoGenericoModel;
            if (!result.Sucesso)
                return BadRequest(result);
            return Ok(result);

        }

        [HttpPost]
        public async Task<ActionResult<RetornoGenericoModel>> Post([FromBody] CriarpublicacaoDeMensagem body)
        {
            var result = await _handlerEnviar.Handle(body) as RetornoGenericoModel;
            if (!result.Sucesso)
                return BadRequest(result);
            return Ok(result);
        }
    }
}