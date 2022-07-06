using DespesasApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DespesasApi.Infra.Mappings
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GetDate()");

            builder.HasMany(x => x.Lancamentos).WithOne(x => x.Categoria).HasForeignKey(x => x.CategoriaId);
        }
    }
}
