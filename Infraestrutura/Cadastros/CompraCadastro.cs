using Dominio;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Infraestrutura.Cadastros
{
    public class CompraCadastro
    {
        private EFContext contexto;
        public CompraCadastro()
        {
            contexto = new EFContext();
        }

        public List<Produto> BuscarProdutosEstoqueBaixo()
        {
            IQueryable<Produto> produtos = from produto in contexto.Produto
                                     where produto.QuantidadeEmEstoque < produto.QuantidadeEstoqueMinimo
                                     select produto;
            return produtos.ToList();
        }

        public Produto BuscarDetalhesProduto(long IdProduto)
        {
            Produto prod = contexto.Produto.Where(p => p.IdProduto == IdProduto).First();
            return prod;
        }

        public List<Compra> BuscarTodosAguardandoRecebimento()
        {
            IQueryable<Compra> compras = from compra in contexto.Compra.Include("PedidoFornecedor")
                                         where compra.PedidoFornecedor.Status == Dominio.Enums.StatusPedidoFornecedor.AguardandoRecebimento
                                         select compra;
            return compras.ToList();
        }

        public Compra Adicionar(Compra novaCompra)
        {
            contexto.Compra.Add(novaCompra);
            contexto.SaveChanges();
            return novaCompra;
        }

        public void Editar(Compra compra)
        {
            contexto.Entry(compra).State = EntityState.Modified;
            contexto.SaveChanges();
        }

    }
}
