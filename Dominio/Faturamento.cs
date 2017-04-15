namespace Dominio
{
    public class Faturamento
    {
        public Faturamento() { }

        public long IdFaturamento { get; set; }
        public PedidoCliente Pedido { get; set; }
        public Pagamento Pagamento { get; set; }
        public NotaFiscal NotaFiscal { get; set; }
    }
}
