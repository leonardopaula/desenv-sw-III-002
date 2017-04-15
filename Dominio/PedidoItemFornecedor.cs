using System;

namespace Dominio
{
    public class PedidoItemFornecedor
    {
        public PedidoItemFornecedor() { }

        public long IdPedidoItemFornecedor { get; set; }
        public Produto Produto { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataPrevista { get; set; }
    }
}
