using Dominio;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Infraestrutura.Mapeamento
{
    public class PedidoClienteMap : EntityTypeConfiguration<PedidoCliente>
    {
        public PedidoClienteMap()
        {
            ToTable("PedidoCliente");
            HasKey(p => p.IdPedidoCliente);
            Property(p => p.IdPedidoCliente).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Status).IsRequired();
            Property(p => p.Numero).IsRequired();
            Property(p => p.Data).IsRequired();

            Property(p => p.CodigoRastreio).IsOptional();
            Property(p => p.NumDocPag).IsOptional();

            HasRequired(p => p.Cliente).WithMany().HasForeignKey(p => p.IdCliente);
            HasRequired(p => p.EnderecoEntrega).WithMany().HasForeignKey(p => p.IdEnderecoEntrega);
        }
    }
}
