using Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Infraestrutura.Mapeamento
{
    public class PedidoClienteMap : EntityTypeConfiguration<PedidoCliente>
    {
        public PedidoClienteMap()
        {
            ToTable("PedidoCliente");
            HasKey(p => p.IdPedidoCliente);
            
            Property(p => p.Status).IsRequired();
            Property(p => p.Numero).IsRequired();
            Property(p => p.Data).IsRequired();

            Property(p => p.CodigoRastreio).IsOptional();
            Property(p => p.NumDocPag).IsOptional();

            HasRequired(p => p.Cliente).WithMany().HasForeignKey(p => p.IdCliente);
            HasMany(p => p.Produtos).WithMany().Map(m => {
                m.ToTable("PedidoCliente_Produtos");
                m.MapLeftKey("IdPedidoCliente");
                m.MapRightKey("IdProduto");
            });
        }
    }
}
