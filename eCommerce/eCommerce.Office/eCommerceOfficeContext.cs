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
            #region Mapping: ColaboradorSetor
            /*
             * Muitos para Muitos usando 2 relacionamentos de Um para Muitos
             * Many-To-Many: 2x One-To-Many
             */
            modelBuilder.Entity<ColaboradorSetor>().HasKey(a=> new {a.SetorId, a.ColaboradorId });
            modelBuilder.Entity<ColaboradorSetor>()
                .HasOne(a => a.Colaborador)
                .WithMany(a => a.ColaboradorSetores)
                .HasForeignKey(a => a.ColaboradorId);
            modelBuilder.Entity<ColaboradorSetor>()
                .HasOne(a => a.Setor)
                .WithMany(a => a.ColaboradoresSetores)
                .HasForeignKey(a => a.SetorId);
            /*
            //modelBuilder.Entity<Colaborador>().HasMany(a => a.ColaboradorSetores).WithOne(a=>a.Colaborador).HasForeignKey(a=>a.ColaboradorId);
            //modelBuilder.Entity<Setor>().HasMany(a => a.ColaboradoresSetores).WithOne(a => a.Setor).HasForeignKey(a => a.SetorId);
            */
            #endregion

            #region Mapping: Colaborador <=> Turma (EF Core 5+)
            modelBuilder.Entity<Colaborador>().HasMany(a => a.Turmas).WithMany(a => a.Colaboradores);
            #endregion
            #region Seeds
            modelBuilder.Entity<Colaborador>().HasData(
                new Colaborador() { Id = 1, Nome = "José" },
                new Colaborador() { Id = 2, Nome = "Maria" },
                new Colaborador() { Id = 3, Nome = "Felipe" },
                new Colaborador() { Id = 4, Nome = "Tiago" },
                new Colaborador() { Id = 5, Nome = "Mariano" },
                new Colaborador() { Id = 6, Nome = "Jessica" },
                new Colaborador() { Id = 7, Nome = "Vivian" }
            );
            modelBuilder.Entity<Setor>().HasData(
                new Setor() { Id = 1, Nome = "Lógistica" },
                new Setor() { Id = 2, Nome = "Separação" },
                new Setor() { Id = 3, Nome = "Financeiro" },
                new Setor() { Id = 4, Nome = "Administrativo" }
            );

            modelBuilder.Entity<ColaboradorSetor>().HasData(
                new ColaboradorSetor() { SetorId = 1, ColaboradorId = 1, Criado = DateTimeOffset.Now },
                new ColaboradorSetor() { SetorId = 1, ColaboradorId = 6, Criado = DateTimeOffset.Now },
                new ColaboradorSetor() { SetorId = 2, ColaboradorId = 5, Criado = DateTimeOffset.Now },
                new ColaboradorSetor() { SetorId = 2, ColaboradorId = 4, Criado = DateTimeOffset.Now },
                new ColaboradorSetor() { SetorId = 3, ColaboradorId = 7, Criado = DateTimeOffset.Now },
                new ColaboradorSetor() { SetorId = 4, ColaboradorId = 2, Criado = DateTimeOffset.Now },
                new ColaboradorSetor() { SetorId = 4, ColaboradorId = 3, Criado = DateTimeOffset.Now }
            );

            modelBuilder.Entity<Turma>().HasData(
                new Turma() { Id = 1, Nome = "Turma A1" },
                new Turma() { Id = 2, Nome = "Turma A2" },
                new Turma() { Id = 3, Nome = "Turma A3" },
                new Turma() { Id = 4, Nome = "Turma A4" },
                new Turma() { Id = 5, Nome = "Turma A5" }
            );
            #endregion
        }
    }
}
