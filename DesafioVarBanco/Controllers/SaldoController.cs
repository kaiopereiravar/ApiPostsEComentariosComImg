using DesafioVarBanco.Application.SaldoConta;
using DesafioVarBancoRepository;
using Microsoft.AspNetCore.Mvc;

namespace DesafioVarBanco.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaldoController : ControllerBase
    {
        private readonly DesafioVarBancoContext _context;

        public SaldoController(DesafioVarBancoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult VerSaldoConta()
        {
            var SaldoContaService = new SaldoContaService(_context);
            var saldo = SaldoContaService.VerSaldoConta();

            if(saldo == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(saldo);
            }
        }
    }
}
