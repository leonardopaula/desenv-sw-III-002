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

        public long idPagamento { get; set; }
        public int meioPagamento { get; set; }
        public DateTime data { get; set; }
        public long origem { get; set; }
    }
}
