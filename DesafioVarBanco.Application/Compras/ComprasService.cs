using DesafioVarBancoRepository;
using DesafioVarBancoRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesafioVarBanco.Application.Compras
{
    public class ComprasService
    {
        private readonly DesafioVarBancoContext _context;

        public ComprasService(DesafioVarBancoContext context)
        {
            _context = context;
        }

        public List<TabHistoricoCompras> VerHistoricoCompras()
        {
            try
            {
                var HistoricoCompras = _context.TabHistoricoCompras.ToList();
                return HistoricoCompras;

            }
            catch(Exception ex)
            {
                return null;
            }
        }
        
        public bool Pessoa(ComprasRequest request)
        {
            try
            {
                var pessoa = new TabPessoa()
                {
                    Conta_Corrente = request.Conta_Corrente,
                    NumeroCartao = request.NumeroCartao,
                    Cvv = request.Cvv,
                    ValorCompra = request.ValorCompra,
                    DataCompra = request.DataCompra,
                    FormasPagamento = request.FormasPagamento
                };

                var saldo = _context.tabSaldo.FirstOrDefault(x => x.Saldo == Saldo);
                if (saldo => request.ValorCompra)
                {
                    _context.tabSaldo
                };

                _context.tabPessoa.Add(pessoa);
                _context.SaveChanges();
                return true;
            }

            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
