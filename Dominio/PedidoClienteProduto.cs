namespace Dominio
{
    public class PedidoClienteProduto
    {
        public PedidoClienteProduto() { }

        public long IdPedidoClienteProduto { get; set; }
        public long IdProduto { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public long IdPedidoCliente { get; set; }
        public PedidoCliente PedidoCliente { get; set; }
    }
}
