namespace Dominio
{
    public class Faturamento
    {
        public Faturamento() { }

        public long IdFaturamento { get; set; }

        public long IdPedidoCliente { get; set; }
        public PedidoCliente PedidoCliente { get; set; }

        public long IdPagamento { get; set; }
        public Pagamento Pagamento { get; set; }

        public long? IdNotaFiscal { get; set; }
        public NotaFiscal NotaFiscal { get; set; }
    }
}
