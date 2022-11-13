using Microsoft.AspNetCore.Mvc;

namespace smartSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public AlunoController()
        {
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Alunos: teste, Nicolas, Alexandre");
        }
    }
}