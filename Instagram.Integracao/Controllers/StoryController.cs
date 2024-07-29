using Microsoft.AspNetCore.Mvc;

namespace Instagram.Integracao.Controllers
{
    [ApiController]
    [Route("/v1/story")]
    public class StoryController : ControllerBase
    {
        [HttpPost]
        public void Post([FromBody] object body) { }
    }
}