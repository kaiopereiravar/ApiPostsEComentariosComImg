using DesafioVarBancoRepository;
using DesafioVarBancoRepository.Models;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesafioVarBanco.Application.SaldoConta
{
    public class SaldoContaService
    {
        private readonly DesafioVarBancoContext _context;

        public SaldoContaService(DesafioVarBancoContext context)
        {
            _context = context;
        }

        public List<TabSaldo> VerSaldoConta()
        {
            try
            {
                var saldo = _context.tabSaldo.ToList();
                return saldo;
            } 
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
