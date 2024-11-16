using Microsoft.EntityFrameworkCore;
using IFSPStore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace IFSPStore.Repository.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(x => x.Id);

            builder.Property(u => u.Senha)
                   .HasColumnName("Senha")
                   .HasMaxLength(45)
                   .IsRequired(true);

            builder.Property(u => u.Login)
                   .HasColumnName("Login")
                   .HasMaxLength(45)
                   .IsRequired(true);

            builder.Property(u => u.DataCadastro)
                   .HasColumnName("DataCadastro")
                   .IsRequired(true);

            builder.Property(u => u.DataLogin)
                   .HasColumnName("DataLogin")
                   .IsRequired(true);
        }
    }
}
