using Microsoft.AspNetCore.Mvc;

namespace smartSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        public ProfessorController()
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Professores: teste, Nicolas, Alexandre");
        }
    }
}