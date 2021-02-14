using Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Enginer.Controllers
{
    // Habilitar o cors *
    [EnableCors("AllowSpecificOrigin")]
    // Rota Home
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ApiContext _apiContext;

        public HomeController(ApiContext context)
        {
            _apiContext = context;
        }

        // GET: api/v1/Home
        [HttpGet]
        public IActionResult GetHome()
        {
            string NowDay = DateTime.Now.ToString("yyy-MM-dd"); // Converte para string com formato Dia/Mes/Ano

            DateTime Start = Convert.ToDateTime(NowDay + "T00:00:00"); // converte e cria uma data com horario novo

            DateTime End = Convert.ToDateTime(NowDay + "T23:59:59"); // converte e cria uma data com horario novo

            // Pega todos os registro de clientes e traz em contagem
            var _AllClient = _apiContext.Client.Count();
            // Pega todos os registro de clientes da data de hoje e tras em contagem
            var _AllClientNow = _apiContext.Client.Where(x => x.CreatAt >= Start && x.CreatAt <= End).Count();
            // Pega os ultimos 5 registros de clientes e tras em listas 
            var _ClientTake = _apiContext.Client.OrderByDescending(x => x.CreatAt).Take(5).ToList();

            // Criando um novo Objeto e passando os dados para ele
            return Ok(new
            {
                AllClientCount = _AllClient,
                AllClientNowCount = _AllClientNow,
                Clients = _ClientTake
            });
        }
    }
}
