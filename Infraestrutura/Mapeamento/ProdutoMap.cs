﻿using Dominio;
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
            Property(c => c.QuantidadeEstoqueMinimo).IsRequired();
            Property(c => c.QuantidadeEstoqueMinimo).IsRequired();
            Property(c => c.Referencia).IsRequired();

        }
    }
}
