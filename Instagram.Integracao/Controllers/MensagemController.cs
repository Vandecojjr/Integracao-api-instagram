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
        private readonly IHandler<CriarpublicacaoDeMensagem> _handler;

        public MensagemController(IHandler<CriarpublicacaoDeMensagem> handler)
        {
            _handler = handler;
        }


        [HttpGet]
        public void Get() { }

        [HttpPost]
        public ActionResult<RetornoGenericoModel> Post([FromBody] CriarpublicacaoDeMensagem body)
        {
            var result = (RetornoGenericoModel)_handler.Handle(body);
            if (!result.Sucesso)
                return BadRequest(result);
            return Ok(result);
        }

    }
}