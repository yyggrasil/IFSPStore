using Microsoft.EntityFrameworkCore;
using IFSPStore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFSPStore.Repository.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            // Define a tabela e a chave primária
            builder.ToTable("Produto", "ifspStoreBD");
            builder.HasKey(p => p.Id);

            // Mapeamento das propriedades
            builder.Property(p => p.Id)
                   .HasColumnName("id")
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
                   .HasColumnName("Nome")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(p => p.Preco)
                   .HasColumnName("Preço")
                   .HasColumnType("decimal(10,2)")
                   .IsRequired(false);

            builder.Property(p => p.Quantidade)
                   .HasColumnName("Quantidade")
                   .IsRequired(false);

            builder.Property(p => p.DataCompra)
                   .HasColumnName("DataCompra")
                   .HasColumnType("date")
                   .IsRequired(false);

            builder.Property(p => p.UnidadeVenda)
                   .HasColumnName("UnidadeVenda")
                   .HasMaxLength(10)
                   .IsRequired(false);

            builder.Property(p => p.Grupo)
                   .HasColumnName("idGrupo")
                   .IsRequired();

            // Configuração do relacionamento com Grupo
            builder.HasOne(p => p.Grupo);
        }
    }
}
