using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models.FluentAPI
{
    public class eCommerceFluentContext : DbContext
    {
        public eCommerceFluentContext(DbContextOptions<eCommerceFluentContext> options) : base(options)
        {

        }

        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Contato>? Contatos { get; set; }
        public DbSet<EnderecoEntrega>? EnderecosEntrega { get; set; }
        public DbSet<Departamento>? Departamentos { get; set; }
    }
}
