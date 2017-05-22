using Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Infraestrutura.Mapeamento
{
    public class ExcecaoNFMap : EntityTypeConfiguration<ExcecaoNF>
    {
        public ExcecaoNFMap()
        {
            ToTable("ExcecaoNF");
            HasKey(e => e.IdExcecaoNF);
            Property(x => x.QuantidadeAguardada).IsRequired();
            Property(x => x.QuantidadeRecebida).IsRequired();
            HasRequired(x => x.PedidoItemFornecedor).WithMany().HasForeignKey(e => e.IdPedidoItemFornecedor);
            HasRequired(x => x.Compra).WithMany(c => c.Excecoes).HasForeignKey(e => e.IdCompra);
            
        }
    }
}
