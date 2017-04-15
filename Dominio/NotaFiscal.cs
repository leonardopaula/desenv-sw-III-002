using System;

namespace Dominio
{
    public class NotaFiscal
    {
        public NotaFiscal() { }

        public long IdNotaFiscal { get; set; }
        public decimal Impostos { get; set; }
        public decimal ValorTotal { get; set; }

        public Faturamento Faturamento { get; set; }
    }
}
