using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Compra
    {
        public Compra() { }

        private long IdCompra { get; set; }
        private int NumeroNF { get; set; }
        private DateTime Data { get; set; }

        private List<Produto> Produtos { get; set; }

        private long IdPedidoFornecedor { get; set; }
    }
}
