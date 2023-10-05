using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioVarBancoRepository.Models
{
    public class TabHistoricoCompras
    {
        public int Id { get; set; }

        public DateTime DataCompra { get; set; }

        public string StatusCompra { get; set; }

        public int ContaCorrente { get; set; }
    }
}
