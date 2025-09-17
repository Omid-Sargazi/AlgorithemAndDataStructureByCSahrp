using APIExamples.GUID;
using Microsoft.AspNetCore.Mvc;

namespace APIExamples.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController
    {
        private readonly IGuidService _service1;
        private readonly IGuidService _service2;

        public TestController(IGuidService service1, IGuidService service2)
        {
            _service1 = service1;
            _service2 = service2;
        }

        [HttpGet]
        public string Get()
        {
            return $"Service1: {_service1.GetGuid()}, Service2: {_service2.GetGuid()}";
        }
    }
}