using Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Infraestrutura.Mapeamento
{
    public class PedidoItemFornecedorMap : EntityTypeConfiguration<PedidoItemFornecedor>
    {
        public PedidoItemFornecedorMap()
        {
            ToTable("PedidoItemFornecedor");
            HasKey(p => p.IdPedidoItemFornecedor);
            Property(p => p.Quantidade).IsRequired();
            Property(p => p.DataPrevista).IsRequired();
            HasRequired(p => p.Produto).WithMany().HasForeignKey(p => p.IdProduto);
            HasRequired(p => p.Fornecedor).WithMany().HasForeignKey(p => p.IdFornecedor);

            HasRequired(p => p.PedidoFornecedor)
                .WithMany(p => p.PedidoItem)
                .Map(m => m.MapKey("IdPedidoItem"));
        }
    }
}
