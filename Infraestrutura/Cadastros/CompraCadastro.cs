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

        public Compra BuscarCompra(long IdCompra)
        {
            var res = contexto.Compra
                .Include("Pedidos")
                .Include("Pedidos.Produto")
                .Include("Pedidos.Fornecedor");
                
            return res.FirstOrDefault(c=>c.IdCompra == IdCompra);
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
            return contexto.Produto.Where(p => p.IdProduto == IdProduto)
                .Include("Fornecedores")
                .First();

        }

        public List<Compra> BuscarTodosAguardandoRecebimento()
        {
            IQueryable<Compra> compras = from compra in contexto.Compra
                                         where compra.Status == Dominio.Enums.StatusCompra.AguardandoRecebimento
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

        public void ConfirmarRecebimento(long idCompra)
        {
            var compra = BuscarCompra(idCompra);
            compra.Status = Dominio.Enums.StatusCompra.Recebido;
            Editar(compra);
        }

    }
}
