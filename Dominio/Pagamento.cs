using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pagamento
    {
        public Pagamento () { }

        private long idPagamento { get; set; }
        private int meioPagamento { get; set; }
        private DateTime data { get; set; }
        private long origem { get; set; }
    }
}
