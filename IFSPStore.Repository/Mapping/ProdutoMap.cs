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
            builder.ToTable("Produtos");
            builder.HasKey(p => p.Id);

            // Mapeamento das propriedades
            builder.Property(p => p.Nome)
                   .HasColumnName("Nome")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(p => p.Preco)
                   .HasColumnName("Preco")
                   .HasColumnType("decimal(10,2)")
                   .IsRequired();

            builder.Property(p => p.Quantidade)
                   .HasColumnName("Quantidade")
                   .IsRequired();

            builder.Property(p => p.DataCompra)
                   .HasColumnName("DataCompra")
                   .HasColumnType("date")
                   .IsRequired();

            builder.Property(p => p.UnidadeVenda)
                   .HasColumnName("UnidadeVenda")
                   .HasMaxLength(10)
                   .IsRequired();

            // Configuração do relacionamento com Grupo
            builder.HasOne(p => p.Grupo);
        }
    }
}
