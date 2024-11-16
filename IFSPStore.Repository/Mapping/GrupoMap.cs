using Microsoft.EntityFrameworkCore;
using IFSPStore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFSPStore.Repository.Mapping
{
    public class GrupoMap : IEntityTypeConfiguration<Grupo>
    {
        public void Configure(EntityTypeBuilder<Grupo> builder)
        {
            // Define a tabela e a chave primária
            builder.ToTable("Grupos");
            builder.HasKey(g => g.Id);

            // Mapeamento das propriedades

            builder.Property(g => g.Nome)
                   .HasColumnName("Nome")
                   .HasMaxLength(45)
                   .IsRequired();
        }
    }
}
