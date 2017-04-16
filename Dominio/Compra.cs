using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Compra
    {
        public Compra() { }

        public long IdCompra { get; set; }
        public int NumeroNF { get; set; }
        public DateTime Data { get; set; }

        public List<Produto> Produtos { get; set; }

        public PedidoFornecedor PedidoFornecedor { get; set; }
        public long IdPedidoFornecedor { get; set; }
    }
}
