using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class PedidoCliente
    {
        public PedidoCliente() { }

        private long idPedidoCliente { get; set; }
        private List<Produto> produtos {get; set; }
        private String codigoRastreio { get; set; }
        private int status { get; set; }
        private int numero { get; set; }
        private int numDocPag { get; set; }
        private long idClient { get; set; }
        private DateTime data { get; set; }
    }
}
