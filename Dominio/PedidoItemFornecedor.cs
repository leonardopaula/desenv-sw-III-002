using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class PedidoItemFornecedor
    {
        public PedidoItemFornecedor() { }

        private long idPedidoItemFornecedor { get; set; }
        private Produto produto { get; set; }
        private Fornecedor fornecedor { get; set; }
        private int quantidade { get; set; }
        private DateTime dataPrevista { get; set; }
    }
}
