using Microsoft.EntityFrameworkCore;
using IFSPStore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFSPStore.Repository.Mapping
{
    public class CidadeMap : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            // Define a tabela e a chave primária
            builder.ToTable("Cidade", "ifspStoreBD");
            builder.HasKey(c => c.Id);

            // Mapeamento das propriedades
            builder.Property(c => c.Nome)
                   .HasColumnName("Nome")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.Estado)
                   .HasColumnName("Estado")
                   .HasMaxLength(2)
                   .IsRequired(false);
        }
    }
}
