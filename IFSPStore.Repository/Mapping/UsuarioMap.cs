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
            builder.ToTable("Usuario", "ifspStoreBD");

            builder.HasKey(x => x.Id);

            builder.Property(u => u.Senha)
                   .HasColumnName("Senha")
                   .HasMaxLength(45)
                   .IsRequired(false);

            builder.Property(u => u.Login)
                   .HasColumnName("Login")
                   .HasMaxLength(45)
                   .IsRequired(false);

            builder.Property(u => u.DataCadastro)
                   .HasColumnName("DataCadastro")
                   .HasColumnType("timestamp")
                   .IsRequired(false);

            builder.Property(u => u.DataLogin)
                   .HasColumnName("DataLogin")
                   .HasColumnType("timestamp")
                   .IsRequired(false);

            builder.Property(u => u.Ativo)
                   .HasColumnName("Ativo")
                   .HasColumnType("binary(1)")
                   .IsRequired(false);
        }


    }
    }
}
