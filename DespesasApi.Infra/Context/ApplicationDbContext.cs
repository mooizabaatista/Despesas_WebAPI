using DespesasApi.Domain.Entities;
using DespesasApi.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace DespesasApi.Infra.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Categoria>? Categorias { get; set; }
        public DbSet<Lancamento>? Lancamentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-DGE3J5P\SQLEXPRESS;Database=DespesasApiDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
            modelBuilder.ApplyConfiguration(new LancamentoConfiguration());

            //modelBuilder.Entity<Categoria>().Property(x => x.Id).ValueGeneratedOnAdd();
            //modelBuilder.Entity<Lancamento>().Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
