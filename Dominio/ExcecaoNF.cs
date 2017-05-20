namespace Dominio
{
    public class ExcecaoNF
    {
        public long IdExcecaoNF { get; set; }
        public Compra Compra { get; set; }
        public long IdCompra { get; set; }
        public PedidoItemFornecedor PedidoItemFornecedor { get; set; }
        public long IdPedidoItemFornecedor { get; set; }
        public int QuantidadeAguardada { get; set; }
        public int QuantidadeRecebida { get; set; }
    }
}
