using Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Infraestrutura.Mapeamento
{
    public class CompraMap : EntityTypeConfiguration<Compra>
    {
        public CompraMap()
        {
            ToTable("Compra");

            // Chave primária
            HasKey(c => c.IdCompra);
            Property(c => c.Data).IsRequired();
            Property(c => c.NumeroNF).IsOptional();

            /*
            HasMany(c => c.Produtos). // Definimos como obrigatório o relacionamento com Produtos, ou seja, só salva Compras que contenham Produtos relacionados
            WithMany() // Para os Produtos é opcional ter relacionamentos com Compras
            .Map(m =>
            {
                m.ToTable("CompraProduto"); // Setando que o relacionamento irá para a tabela CompraProduto
                m.MapLeftKey("IdCompra"); // Mapeando a chave primária de Compra na coluna de chave estrangeira IdCompra em CompraProduto
                m.MapRightKey("IdProduto");
            });*/
        }
    }
}
