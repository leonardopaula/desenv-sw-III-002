using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class NotaFiscal
    {
        public NotaFiscal() { }

        public long idNotaFiscal { get; set; }
        public ICustomFormatter impostos { get; set; }
        public ICustomFormatter valorTotal { get; set; }
    }
}
