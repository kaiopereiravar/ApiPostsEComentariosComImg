using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioVarBanco.Application.Compras
{
    public class ComprasRequest
    {
        public int Conta_Corrente { get; set; }

        public int NumeroCartao { get; set; }


        public int Cvv { get; set; }


        public int ValorCompra { get; set; }


        public DateTime DataCompra { get; set; }


        public string FormasPagamento { get; set; }

    }
}
