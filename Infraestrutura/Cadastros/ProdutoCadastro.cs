using Dominio;
using System.Collections.Generic;
using System.Linq;

namespace Infraestrutura.Cadastros
{
    public class ProdutoCadastro
    {
        private EFContext contexto;
        public ProdutoCadastro()
        {
            contexto = new EFContext();
        }

        public Produto BuscarPeloId(long IdProduto)
        {
            IQueryable<Produto> prod = from produto in contexto.Produto
                                       where produto.IdProduto == IdProduto
                                      select produto;
            return prod.FirstOrDefault();
        }

        public List<Produto> BuscarTodos()
        {
            IQueryable<Produto> clientes = from cliente in contexto.Produto
                                           select cliente;
            return clientes.ToList();
        }
    }
}
