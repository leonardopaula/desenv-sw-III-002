using Dominio;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Infraestrutura.Mapeamento
{
    public class PedidoClienteProdutoMap : EntityTypeConfiguration<PedidoClienteProduto>
    {
        public PedidoClienteProdutoMap()
        {
            ToTable("PedidoClienteProduto");
            HasKey(p => p.IdPedidoClienteProduto);
            Property(p => p.IdPedidoClienteProduto).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Quantidade).IsRequired();
            HasRequired(p => p.Produto).WithMany().HasForeignKey(p => p.IdProduto);
            HasRequired(p => p.PedidoCliente).WithMany().HasForeignKey(p => p.IdPedidoCliente);
        }
    }
}
