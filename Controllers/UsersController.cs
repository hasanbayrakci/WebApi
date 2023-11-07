using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApi.Model;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly AppDbContext _db;

        public UsersController(AppDbContext db, ILogger<UsersController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _db.Users;
            if (result.Any())
            {
                return Ok(result.ToArray());
            }
            return NotFound("Kayıt Bulunamadı");
        }

        [HttpGet("GetByName")]
        public IActionResult GetByName(string name)
        {
            var result = _db.Users.Where(x => x.Name == name);

            if (result.Any())
            {
                return Ok(result.ToArray());
            }
            return NotFound("Kayıt Bulunamadı");
        }

    }
}
