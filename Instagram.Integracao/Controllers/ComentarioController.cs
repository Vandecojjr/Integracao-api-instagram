using Microsoft.AspNetCore.Mvc;

namespace Instagram.Integracao.Controllers
{
    [ApiController]
    [Route("/v1/comentario")]
    public class ComentarioController : ControllerBase
    {
        [HttpGet]
        public void Get() { }
    }
}