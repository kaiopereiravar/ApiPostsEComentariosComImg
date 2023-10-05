using DesafioVarBanco.Application.Compras;
using DesafioVarBancoRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace DesafioVarBanco.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComprasController : ControllerBase
    {
        private readonly DesafioVarBancoContext _context;

        public ComprasController(DesafioVarBancoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult VerHistoricoCompras()
        {
            var ComprasService = new ComprasService(_context);
            var compras = ComprasService.VerHistoricoCompras();

            if(compras == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(compras);
            }
        }

        [HttpPost]
        [Route("TabSaldo/{Saldo}")]
        public IActionResult Pessoa([FromBody] ComprasRequest request, int Saldo)
        {
            var ComprasService = new ComprasService(_context);
            var compraFeita = ComprasService.Pessoa(request);

            if (compraFeita == false)
            {
                return BadRequest();
            }
            else
            {
                return Ok(compraFeita);
            }

        }
    }
}
