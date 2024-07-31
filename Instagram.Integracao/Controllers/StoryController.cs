using Instagram.Integracao.Handlers;
using Instagram.Integracao.Handlers.Contracts;
using Instagram.Integracao.Models;
using Instagram.Integracao.Models.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Integracao.Controllers
{
    [ApiController]
    [Route("/v1/story")]
    public class StoryController : ControllerBase
    {
        private readonly IHandler<CriarpublicacaoDeStory> _handler;

        public StoryController(IHandler<CriarpublicacaoDeStory> handler)
        {
            _handler = handler;
        }


        [HttpPost]
        public ActionResult<RetornoGenericoModel> Post([FromBody] CriarpublicacaoDeStory body)
        {
            var result = (RetornoGenericoModel)_handler.Handle(body);
            if (!result.Sucesso)
                return BadRequest(result);
            return Ok(result);
        }
    }
}