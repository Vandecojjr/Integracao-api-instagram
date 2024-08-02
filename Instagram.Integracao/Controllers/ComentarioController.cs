using Instagram.Integracao.Handlers.Contracts;
using Instagram.Integracao.Models;
using Instagram.Integracao.Models.Contracts;
using Instagram.Integracao.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Integracao.Controllers
{
    [ApiController]
    [Route("/v1/comentario")]
    public class ComentarioController : ControllerBase
    {
        private readonly IHandler<CriarBuscaDeComentario> _handler;

        public ComentarioController(IHandler<CriarBuscaDeComentario> handler)
        {
            _handler = handler;
        }

        [HttpGet]
        public async Task<ActionResult<RetornoGenericoModel>> Get([FromQuery] string? postId)
        {
            var result = await _handler.Handle(new CriarBuscaDeComentario { idDoPost = postId }) as RetornoGenericoModel;
            if (!result.Sucesso)
                return BadRequest(result);
            return Ok(result);

        }
    }
}