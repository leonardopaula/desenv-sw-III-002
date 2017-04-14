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

        public long idPedidoItemFornecedor { get; set; }
        public Produto produto { get; set; }
        public Fornecedor fornecedor { get; set; }
        public int quantidade { get; set; }
        public DateTime dataPrevista { get; set; }
    }
}
