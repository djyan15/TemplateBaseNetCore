using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TemplateBase.Core.Interfaces;

namespace TemplateBase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestClassController : ControllerBase
    {
        private readonly ITestClassService _testClassService;
        public TestClassController(ITestClassService testClassService)
        {
            _testClassService = testClassService;
        }

        [HttpGet]
        public IActionResult GetTests()
        {
            var response = _testClassService.GetTests();

            return Ok(response);
        }
    }
}
