using eCommerce.Office.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Office
{
    /*
     * EF CORE < 5 = 3.1, 3.0, 2.1, 2.0, 1.0 
     * Many-To-Many: 2x = One-To-Many
     */
    public class eCommerceOfficeContext : DbContext
    {
        public DbSet<Colaborador>? Colaboradores { get; set; }
        public DbSet<ColaboradorSetor>? ColaboradoresSetores { get; set; }
        public DbSet<Setor>? Setores { get; set; }
        public DbSet<Turma>? Turmas { get; set; }
        public DbSet<Veiculo>? Veiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=eCommerceOffice;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
             * Muitos para Muitos usando 2 relacionamentos de Um para Muitos
             * Many-To-Many: 2x One-To-Many
             */
            modelBuilder.Entity<ColaboradorSetor>().HasKey(a=> new {a.SetorId, a.ColaboradorId });
            modelBuilder.Entity<Colaborador>().HasMany(a => a.ColaboradorSetores).WithOne(a=>a.Colaborador).HasForeignKey(a=>a.ColaboradorId);
            modelBuilder.Entity<Setor>().HasMany(a => a.ColaboradoresSetores).WithOne(a => a.Setor).HasForeignKey(a => a.SetorId);
        }
    }
}
