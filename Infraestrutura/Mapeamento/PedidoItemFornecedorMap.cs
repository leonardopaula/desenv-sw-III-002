using Dominio;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Infraestrutura.Mapeamento
{
    public class PedidoItemFornecedorMap : EntityTypeConfiguration<PedidoItemFornecedor>
    {
        public PedidoItemFornecedorMap()
        {
            ToTable("PedidoItemFornecedor");
            HasKey(p => p.IdPedidoItemFornecedor);
            Property(p => p.IdPedidoItemFornecedor).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Quantidade).IsRequired();
            Property(p => p.DataPrevista).IsRequired();
            HasRequired(p => p.Produto).WithMany().HasForeignKey(p => p.IdProduto);
            HasRequired(p => p.Fornecedor).WithMany().HasForeignKey(p => p.IdFornecedor);
        }
    }
}
