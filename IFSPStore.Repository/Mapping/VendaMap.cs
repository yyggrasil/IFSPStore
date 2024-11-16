﻿using Microsoft.EntityFrameworkCore;
using IFSPStore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace IFSPStore.Repository.Mapping 
{ 
    public class VendaMap : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable("Vendas");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Data)
                .IsRequired();

            builder.Property(prop => prop.ValorTotal)
                .IsRequired();

            builder.HasOne(prop => prop.Cliente);

            builder.HasMany(prop => prop.Items)
                .WithOne(prop => prop.Venda)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class VendaItemMap : IEntityTypeConfiguration<VendaItem>
    {
        public void Configure(EntityTypeBuilder<VendaItem> builder)
        {
            builder.ToTable("VendaItens");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Quantidade)
                .IsRequired();

            builder.Property(prop => prop.ValorUnitario)
                .IsRequired();

            builder.Property(prop => prop.ValorTotal)
                .IsRequired();

            builder.HasOne(prop => prop.Produto);

            builder.HasOne(prop => prop.Venda)
                .WithMany(prop => prop.Items)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
