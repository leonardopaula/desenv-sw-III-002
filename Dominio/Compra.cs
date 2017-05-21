using Dominio.Enums;
using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Compra
    {
        public Compra() { Excecoes = new List<ExcecaoNF>(); Pedidos = new List<PedidoItemFornecedor>(); }

        public long IdCompra { get; set; }
        public int NumeroNF { get; set; }
        public DateTime Data { get; set; }
        public StatusCompra Status { get; set; }
        public List<PedidoItemFornecedor> Pedidos { get; set; }
        public List<ExcecaoNF> Excecoes { get; set; }
    }
}
