using Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Enginer.Controllers
{
    // Habilitar o cors *
    [EnableCors("AllowSpecificOrigin")]
    // Rota Gender
    [Route("api/v1/[controller]")]
    [ApiController]   
    public class GenderController : ControllerBase
    {
        private readonly ApiContext _apiContext;

        public GenderController(ApiContext context)
        {
            _apiContext = context;
        }

        // GET: api/v1/Gender
        [HttpGet]
        public async Task<IActionResult> GetGender()
        {
            var _gender = await _apiContext.Gender.ToListAsync();

            return Ok(_gender);
        }

        // GET: api/v1/Gender/{id} -> int
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGender([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var _gender = await _apiContext.Gender.FindAsync(id);

            if (_gender == null)
            {
                return NotFound();
            }

            return Ok(_gender);
        }
    }
}