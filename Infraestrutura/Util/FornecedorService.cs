namespace Infraestrutura.Util
{
    public class FornecedorService
    {
        private FornecedorServiceRef.ServiceFornecedorClient cliente;

        public FornecedorService()
        {            
            cliente = new FornecedorServiceRef.ServiceFornecedorClient();
        }

        public FornecedorServiceRef.RetornoRequisicao ObterDisponibilidadeDeProduto(string referenciaProduto, int quantidade)
        {
            FornecedorServiceRef.ProdutoConsultado produtoRequisicao = new FornecedorServiceRef.ProdutoConsultado() { QuantidadeRequerida = quantidade, Referencia = referenciaProduto };
            return cliente.ObterDisponibilidadeProduto(produtoRequisicao);
        }
    }
}
