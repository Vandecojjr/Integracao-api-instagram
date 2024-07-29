using Microsoft.AspNetCore.Mvc;

namespace Instagram.Integracao.Controllers
{
    [ApiController]
    [Route("/v1/mensagem")]
    public class MensagemController : ControllerBase
    {
        [HttpGet]
        public void Get() { }

        [HttpPost]
        public void Post([FromBody] object body) { }
    }
}