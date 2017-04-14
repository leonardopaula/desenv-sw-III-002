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

        public long idPedidoCliente { get; set; }
        public List<Produto> produtos {get; set; }
        public String codigoRastreio { get; set; }
        public int status { get; set; }
        public int numero { get; set; }
        public int numDocPag { get; set; }
        public long idClient { get; set; }
        public DateTime data { get; set; }
    }
}
