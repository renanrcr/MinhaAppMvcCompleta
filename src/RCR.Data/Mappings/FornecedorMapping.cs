using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCR.Business.Models;

namespace RCR.Data.Mappings
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(x => x.Documento)
                .IsRequired()
                .HasColumnType("varchar(14)");

            // 1 : 1 => Fornecedor : Endereço
            builder.HasOne(x => x.Endereco)
                .WithOne(x => x.Fornecedor);

            // 1 : N => Fornecedor : Produtos
            builder.HasMany(x => x.Produtos)
                .WithOne(x => x.Fornecedor)
                .HasForeignKey(x => x.FornecedorId);

            builder.ToTable("Fornecedores");
        }
    }
}
