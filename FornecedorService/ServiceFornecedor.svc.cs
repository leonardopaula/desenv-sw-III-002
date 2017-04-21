using System;

namespace FornecedorService
{
    public class FornecedorService : IServiceFornecedor
    {
        public RetornoRequisicao ObterDisponibilidadeProduto(ProdutoConsultado produto)
        {
            RetornoRequisicao retorno = new RetornoRequisicao(produto.QuantidadeRequerida, produto.Referencia);
            if (produto.QuantidadeRequerida <= 0)
            {
                retorno.Mensagem = "Quantidade inválida";
            }
            if (string.IsNullOrEmpty(produto.Referencia))
            {
                retorno.Mensagem += "A referência é obrigatória";
            }
            if (produto.Referencia.Equals("CI001"))
            {
                retorno.Mensagem += "Produto indisponível na quantidade requisitada";
            }
            else
            {
                retorno.DataEnvio = DateTime.Now.AddMonths(1);
            }
            
            return retorno;
        }
    }
}
