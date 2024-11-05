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
            builder.ToTable("Usuario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome);
            builder.Property(x => x.Senha);
            builder.Property(x => x.Login);
            builder.Property(x => x.Email);
            builder.Property(x => x.DataCadastro);
            builder.Property(x => x.DataLogin);
            builder.Property(x => x.Ativo);


        }
    }
}
