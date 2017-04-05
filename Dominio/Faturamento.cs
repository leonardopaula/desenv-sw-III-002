using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    {
        public Faturamento() { }

        private long idFaturamento { get; set; }
        private PedidoCliente pedido { get; set; }
        private Pagamento pagamento { get; set; }
        private NotaFiscal notaFiscal { get; set; }
    }
}
