using Dominio;
using Infraestrutura.Mapeamento;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Migrations
{
    public class EFContext : DbContext
    {
        public EFContext()
                     : base("DataContext")//nome da connection string utilizada
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
        
        /// <summary>
        /// Definições para todo o contexto
        /// </summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Aqui vamos remover a pluralização padrão do Etity Framework que é em inglês
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            /*Desabilitamos o delete em cascata em relacionamentos 1:N evitando
             ter registros filhos     sem registros pai*/
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //Basicamente a mesma configuração, porém em relacionamenos N:N
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            /*Toda propriedade do tipo string na entidade POCO
             seja configurado como VARCHAR no SQL Server*/
            modelBuilder.Properties<string>()
                      .Configure(p => p.HasColumnType("varchar"));

            /*Toda propriedade do tipo string na entidade POCO seja configurado como VARCHAR (150) no banco de dados */
            modelBuilder.Properties<string>()
                   .Configure(p => p.HasMaxLength(150));

            /*Definimos usando reflexão que toda propriedade que contenha
           Id "Nome da classe" como "IdCompra" por exemplo, seja dada como
           chave primária, caso não tenha sido especificado*/
            modelBuilder.Properties()
               .Where(p => p.Name == "Id" + p.ReflectedType.Name)
               .Configure(p => p.IsKey());

            modelBuilder.Configurations.Add(new CompraMap());
            modelBuilder.Configurations.Add(new ProdutoMap());
            modelBuilder.Configurations.Add(new CompraProdutoMap());
            modelBuilder.Configurations.Add(new FornecedorMap());
            modelBuilder.Configurations.Add(new FornecedorProdutoMap());
        }


    }
}
