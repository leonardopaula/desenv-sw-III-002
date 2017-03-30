using Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Infraestrutura.Mapeamento
{
    public class CompraProdutoMap : EntityTypeConfiguration<CompraProduto>
    {
        public CompraProdutoMap()
        {
            ToTable("CompraProduto");
            HasKey(cp => cp.IdCompraProduto);
        }
    }
}
