using System;

namespace Dominio
{
    public class NotaFiscal
    {
        public NotaFiscal() { }

        public long IdNotaFiscal { get; set; }
        public ICustomFormatter Impostos { get; set; }
        public ICustomFormatter ValorTotal { get; set; }
    }
}
