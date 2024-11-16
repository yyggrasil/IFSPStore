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
            builder.ToTable("Clientes");
            builder.HasKey(c => c.Id);

            // Mapeamento das propriedades

            builder.Property(c => c.Nome)
                   .HasColumnName("Nome")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(c => c.Endereco)
                   .HasColumnName("Endereco")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(c => c.Documento)
                   .HasColumnName("Documento")
                   .HasMaxLength(45)
                   .IsRequired();

            builder.Property(c => c.Bairro)
                   .HasColumnName("Bairro")
                   .HasMaxLength(45)
                   .IsRequired();           

            // Configuração do relacionamento com Cidade
            builder.HasOne(c => c.Cidade);
        }
    }
}
