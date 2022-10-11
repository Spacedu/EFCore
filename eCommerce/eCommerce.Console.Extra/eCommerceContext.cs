using eCommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.API.Database
{
    public class eCommerceContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=eCommerceTemp;Integrated Security=True;");
        }
        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Contato>? Contatos { get; set; }
        public DbSet<EnderecoEntrega>? EnderecosEntrega { get; set; }
        public DbSet<Departamento>? Departamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuarios", t => t.IsTemporal(
                b => {
                    b.HasPeriodStart("PeriodioInicial");
                    b.HasPeriodEnd("PeriodoFinal");
                    b.UseHistoryTable("UsuariosHistorico");
                }
                ));



            modelBuilder.Entity<Usuario>().HasQueryFilter(a => a.SituacaoCadastro == SituacaoCadastro.Ativo);

            /*
             * Conversores
             */
            modelBuilder.Entity<Usuario>().Property(a => a.SituacaoCadastro).HasConversion<string>();
        }
    }
}
