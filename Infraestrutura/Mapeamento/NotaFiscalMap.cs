﻿using Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Infraestrutura.Mapeamento
{
    public class NotaFiscalMap : EntityTypeConfiguration<NotaFiscal>
    {
        public NotaFiscalMap()
        {
            ToTable("NotaFiscal");
            HasKey(n => n.IdNotaFiscal);
            Property(n => n.Impostos).HasPrecision(10,3).IsRequired();
            Property(n => n.ValorTotal).HasPrecision(10, 3).IsRequired();
        }
    }
}