using Dominio;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Infraestrutura.Mapeamento
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            ToTable("Produto");

            HasKey(c => c.IdProduto);
            Property(c => c.Nome).IsRequired();
            Property(c => c.IdProduto).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.QuantidadeEstoqueMinimo).IsRequired();
            Property(c => c.QuantidadeEstoqueMinimo).IsRequired();
            Property(c => c.Referencia).IsRequired();
            Property(c => c.Peso).IsRequired();
            Property(c => c.Preco).IsRequired();
            Property(c => c.UrlImagem).IsOptional();

        }
    }
}
