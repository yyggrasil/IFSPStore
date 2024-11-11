using Microsoft.EntityFrameworkCore;
using IFSPStore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace IFSPStore.Repository.Mapping
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            // Define a tabela e a chave primária
            builder.ToTable("Cliente", "ifspStoreBD");
            builder.HasKey(c => new { c.Id, c.Cidade }); // Chave composta

            // Mapeamento das propriedades
            builder.Property(c => c.Id)
                   .HasColumnName("id")
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(c => c.Nome)
                   .HasColumnName("Nome")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.Endereco)
                   .HasColumnName("Endereco")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.Documento)
                   .HasColumnName("Documento")
                   .HasMaxLength(45)
                   .IsRequired(false);

            builder.Property(c => c.Bairro)
                   .HasColumnName("Bairro")
                   .HasMaxLength(45)
                   .IsRequired(false);

            builder.Property(c => c.Cidade)
                   .HasColumnName("Cidade")
                   .HasMaxLength(45)
                   .IsRequired(false);

            builder.Property(c => c.Cidade)
                   .HasColumnName("idCidade")
                   .IsRequired();

            // Configuração do relacionamento com Cidade
            builder.HasOne(c => c.Cidade)
                   .WithMany()
                   .HasForeignKey(c => c.Cidade)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
