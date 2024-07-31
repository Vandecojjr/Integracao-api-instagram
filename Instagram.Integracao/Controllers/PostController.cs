using Instagram.Integracao.Handlers;
using Instagram.Integracao.Handlers.Contracts;
using Instagram.Integracao.Models;
using Instagram.Integracao.Models.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Integracao.Controllers
{
    [ApiController]
    [Route("/v1/post")]
    public class PostController : ControllerBase
    {
        private readonly IHandler<CriarpublicacaoDePost> _handler;

        public PostController(IHandler<CriarpublicacaoDePost> handler)
        {
            _handler = handler;
        }


        [HttpPost]
        public async Task<ActionResult<RetornoGenericoModel>> Post([FromBody] CriarpublicacaoDePost body)
        {
            var result = await _handler.Handle(body) as RetornoGenericoModel;
            if (!result.Sucesso)
                return BadRequest(result);
            return Ok(result);
        }
    }
}