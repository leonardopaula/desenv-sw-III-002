using Dominio.Enums;
using System;

namespace Dominio
{
    public class Pagamento
    {
        public Pagamento () { }

        public long IdPagamento { get; set; }
        public MeioPagamento MeioPagamento { get; set; }
        public DateTime Data { get; set; }
        public long Origem { get; set; }

        public Faturamento Faturamento { get; set; }
    }
}
