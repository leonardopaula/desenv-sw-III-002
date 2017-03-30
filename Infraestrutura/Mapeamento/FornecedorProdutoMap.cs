using Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Infraestrutura.Mapeamento
{
    public class FornecedorProdutoMap : EntityTypeConfiguration<FornecedorProduto>
    {
        public FornecedorProdutoMap()
        {
            ToTable("FornecedorProduto");
            HasKey(fp => fp.IdFornecedorProduto);
        }
    }
}
