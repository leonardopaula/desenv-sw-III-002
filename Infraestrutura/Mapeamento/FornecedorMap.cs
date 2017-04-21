using Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Infraestrutura.Mapeamento
{
    public class FornecedorMap : EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorMap()
        {
            ToTable("Fornecedor");
            HasKey(f => f.IdFornecedor);
            Property(f => f.Nome).HasMaxLength(150).IsRequired();
            Property(f => f.Email).HasMaxLength(100).IsRequired();

            HasMany(f => f.Produtos)
            .WithMany(f => f.Fornecedores)
            .Map(m =>
            {
                m.MapLeftKey("IdProduto");
                m.MapRightKey("IdFornecedor");
                m.ToTable("FornecedorProduto");
            });
        }
    }
}
