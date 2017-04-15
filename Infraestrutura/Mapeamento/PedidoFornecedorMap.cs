using Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Infraestrutura.Mapeamento
{
    public class PedidoFornecedorMap : EntityTypeConfiguration<PedidoFornecedor>
    {
        public PedidoFornecedorMap()
        {
            ToTable("PedidoFornecedor");
            HasKey(p => p.IdPedidoFornecedor);
            Property(p => p.Status).IsRequired();
        }
    }
}
