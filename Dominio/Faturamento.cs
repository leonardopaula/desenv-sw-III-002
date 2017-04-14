using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Faturamento
    {
        public Faturamento() { }

        public long idFaturamento { get; set; }
        public PedidoCliente pedido { get; set; }
        public Pagamento pagamento { get; set; }
        public NotaFiscal notaFiscal { get; set; }
    }
}
