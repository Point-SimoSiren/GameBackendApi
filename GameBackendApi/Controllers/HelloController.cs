using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameBackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {

        [HttpGet] // filtteri
        public string SayHello()
        {

            string hello = "Hello world!";

            return hello;
        }


        [HttpPost("luku2")]
        public decimal Laske([FromBody] decimal luku1, decimal luku2)
        {
            return luku1 + luku2;
        }

    }
}
