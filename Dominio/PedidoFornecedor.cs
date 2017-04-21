using Dominio.Enums;
using System.Collections.Generic;

namespace Dominio
{
    public class PedidoFornecedor
    {
        public PedidoFornecedor() { }

        public long IdPedidoFornecedor { get; set; }
        public StatusPedidoFornecedor Status { get; set; }
    }
}
