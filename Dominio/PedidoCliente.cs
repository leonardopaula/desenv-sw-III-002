using Dominio.Enums;
using System;
using System.Collections.Generic;

namespace Dominio
{
    public class PedidoCliente
    {
        public PedidoCliente() { }

        public long IdPedidoCliente { get; set; }
        public List<Produto> Produtos {get; set; }
        public String CodigoRastreio { get; set; }
        public StatusPedido Status { get; set; }
        public int Numero { get; set; }
        public int NumDocPag { get; set; }
        public long IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Data { get; set; }

        public Faturamento Faturamento { get; set; }
        public Endereco EnderecoEntrega { get; set; }
        public long IdEnderecoEntrega { get; set; }
    }
}
