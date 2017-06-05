using Dominio;
using Infraestrutura.Mapeamento;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Infraestrutura
{
    public class EFContext : DbContext
    {
        public EFContext()
                     : base("Contexto")//nome da connection string utilizada
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<Faturamento> Faturamento { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<NotaFiscal> NotaFiscal { get; set; }
        public DbSet<Pagamento> Pagamento { get; set; }
        public DbSet<PedidoCliente> PedidoCliente { get; set; }
        public DbSet<PedidoItemFornecedor> PedidoItemFornecedor { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Endereco> Endereco { get; set; }

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

            modelBuilder.Configurations.Add(new ClienteMap());
            modelBuilder.Configurations.Add(new CompraMap());
            modelBuilder.Configurations.Add(new FaturamentoMap());
            modelBuilder.Configurations.Add(new FornecedorMap());
            modelBuilder.Configurations.Add(new FuncionarioMap());
            modelBuilder.Configurations.Add(new NotaFiscalMap());
            modelBuilder.Configurations.Add(new PagamentoMap());
            modelBuilder.Configurations.Add(new PedidoClienteMap());
            modelBuilder.Configurations.Add(new ExcecaoNFMap());
            modelBuilder.Configurations.Add(new PedidoItemFornecedorMap());
            modelBuilder.Configurations.Add(new ProdutoMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new EstadoMap());
            modelBuilder.Configurations.Add(new CidadeMap());
            modelBuilder.Configurations.Add(new EnderecoMap());
        }


    }
}
