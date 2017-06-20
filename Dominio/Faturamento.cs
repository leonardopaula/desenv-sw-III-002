namespace Dominio
{
    public class Faturamento
    {
        public Faturamento() { }

        public long IdFaturamento { get; set; }
        
        public PedidoCliente PedidoCliente { get; set; }
        
        public Pagamento Pagamento { get; set; }
        
        public NotaFiscal NotaFiscal { get; set; }
    }
}
