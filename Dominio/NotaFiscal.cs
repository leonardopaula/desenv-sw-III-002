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

        private long idNotaFiscal { get; set; }
        private ICustomFormatter impostos { get; set; }
        private ICustomFormatter valorTotal { get; set; }
    }
}
