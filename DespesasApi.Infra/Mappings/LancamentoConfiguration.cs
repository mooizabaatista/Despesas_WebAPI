using DespesasApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DespesasApi.Infra.Mappings
{
    public class LancamentoConfiguration : IEntityTypeConfiguration<Lancamento>
    {
        public void Configure(EntityTypeBuilder<Lancamento> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Local)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Data)
                .IsRequired();


            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasMaxLength(50);


            builder.Property(x => x.Valor)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GetDate()");
        }
    }
}
