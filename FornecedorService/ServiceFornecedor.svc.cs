using System;

namespace FornecedorService
{
    public class FornecedorService : IServiceFornecedor
    {
        public bool ObterDisponibilidadeProduto(ProdutoConsultado produto)
        {
            if (produto.QuantidadeRequerida <= 0)
            {
                throw new ArgumentNullException("Quantidade inválida");
            }
            if (string.IsNullOrEmpty(produto.Referencia))
            {
                throw new ArgumentNullException("A referência é obrigatória");
            }
            
            return true;
        }
    }
}
