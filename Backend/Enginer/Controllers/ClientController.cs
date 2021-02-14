using Business;
using Data;
using Enginer.Combo;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Enginer.Controllers
{
    // Habilitar o cors *
    [EnableCors("AllowSpecificOrigin")]
    // Rota Client
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ApiContext _apiContext;

        public ClientController(ApiContext context)
        {
            _apiContext = context;
        }

        // GET: api/v1/Client
        [HttpGet]
        public async Task<IActionResult> GetClient()
        {
            //Inner Join: Cliente e sexo
            var _client = await (from Client in _apiContext.Client
                                 join Gender in _apiContext.Gender on Client.GenderId equals Gender.Id
                                 select new
                                 {
                                     Client,
                                     Gender
                                 }).ToListAsync();

            return Ok(_client);
        }

        // GET: api/v1/Client/{id} -> int
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var _client = await (from Client in _apiContext.Client
                                 join Gender in _apiContext.Gender on Client.GenderId equals Gender.Id
                                 where Client.Id == id
                                 select new
                                 {
                                     Client,
                                     Gender = Gender.Description
                                 }).FirstAsync();


            if (_client == null)
            {
                return NotFound();
            }

            return Ok(_client);
        }

        // PUT: api/v1/Client/{id} -> int & Body -> Object
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient([FromRoute] int id, [FromBody] Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.Id)
            {
                return BadRequest();
            }

            // passado um valor de atualizado
            client.IsUpdate = 1;
            client.CreatAt = DateTime.Now;

            _apiContext.Entry(client).State = EntityState.Modified;

            try
            {
                await _apiContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/v1/Client - Body -> Object
        [HttpPost]
        public async Task<IActionResult> PostClient([FromBody] Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _apiContext.Client.Add(client);
            await _apiContext.SaveChangesAsync();

            return Ok(new { id = client.Id });
        }

        // POST: api/v1/Client/Filter - Body -> Object
        [HttpPost("filter")]
        public async Task<IActionResult> PostClientFilter([FromBody] ClientCombo clientCombo)
        {

            var _client = await (from Client in _apiContext.Client
                                 join Gender in _apiContext.Gender on Client.GenderId equals Gender.Id
                                 where
                                 Client.Name.Contains(clientCombo.Name)
                                 select new
                                 {
                                     Client,
                                     Gender
                                 }).ToListAsync();
            return Ok(_client);

        }

        // DELETE: api/v1/Client/{id} -> int
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var _client = await _apiContext.Client.FindAsync(id);
            if (_client == null)
            {
                return NotFound();
            }

            _apiContext.Client.Remove(_client);
            await _apiContext.SaveChangesAsync();

            return Ok(_client);
        }

        private bool ClientExists(int id)
        {
            // Valida se o cliente existe
            return _apiContext.Client.Any(e => e.Id == id);
        }
    }
}