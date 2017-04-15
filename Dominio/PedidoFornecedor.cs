using Dominio.Enums;

namespace Dominio
{
    public class PedidoFornecedor
    {
        public PedidoFornecedor() { }

        public long IdPedidoFornecedor { get; set; }
        public StatusPedidoFornecedor Status { get; set; }
    }
}
