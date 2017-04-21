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
        public PedidoFornecedor PedidoFornecedor { get; set; }

        // Como temos o PedidoFornecedor, não necessitamos destes campos abaixo
        //public List<Produto> Produtos { get; set; }
        //public long IdPedidoFornecedor { get; set; }
    }
}
