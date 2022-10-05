using eCommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.API.Database
{
    public class eCommerceContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //.UseLazyLoadingProxies() - Habilita o Lazy Loading usando Proxies
            optionsBuilder
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=eCommerce;Integrated Security=True;"
                //, options => options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
                )
                //.LogTo(System.Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
                //.EnableSensitiveDataLogging()
                ;
        }
        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Contato>? Contatos { get; set; }
        public DbSet<EnderecoEntrega>? EnderecosEntrega { get; set; }
        public DbSet<Departamento>? Departamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().Navigation(a => a.Contato).AutoInclude();
        }
    }
}
