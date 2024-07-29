using Microsoft.AspNetCore.Mvc;

namespace Instagram.Integracao.Controllers
{
    [ApiController]
    [Route("/v1/post")]
    public class PostController : ControllerBase
    {
        [HttpPost]
        public void Post([FromBody] object body) { }
    }
}