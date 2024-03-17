using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // GET: All Students
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            String[] studentName = new string[] { "john", "Priyanka", "Maria", "Justin" };
            return Ok(studentName);
        }
    }
}
