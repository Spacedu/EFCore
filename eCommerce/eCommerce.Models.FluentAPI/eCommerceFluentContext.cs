using eCommerce.Models.FluentAPI.Configurations;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Explicações do CAP 07
            /* Table*, 
             * Column*, 
             * NotMapped*, 
             * DatabaseGenerated(ValueGeneratedNever=None, ValueGeneratedOnAdd=Identity, ValueGeneratedOnAddOrUpdate=Computed) 
             * Index*
             * 
             * Key*
             * ForeignKey*
             * 
             * Relacionamentos entre Tabelas/Entidades:
             * Has/With + One/Many = HasOne, HasMany, WithOne, WithMany
             * 
             * OnDelete*
             * 
             * IsRequired*
             * HasMaxLength*
             * HasPrecision*
             */
            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIOS");
            modelBuilder.Entity<Usuario>().Property(a => a.RG).HasColumnName("REGISTRO_GERAL").HasMaxLength(10).HasDefaultValue("RG-AUSENTE").IsRequired();
            modelBuilder.Entity<Usuario>().Ignore(a => a.Sexo);
            modelBuilder.Entity<Usuario>().Property(a => a.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Usuario>().HasIndex("CPF").IsUnique().HasFilter("[CPF] is not null").HasDatabaseName("IX_CPF_UNIQUE");
            modelBuilder.Entity<Usuario>().HasIndex(a=>a.CPF);

            modelBuilder.Entity<Usuario>().HasIndex("CPF", "Email");
            modelBuilder.Entity<Usuario>().HasIndex(a=>new {a.CPF, a.Email});

            modelBuilder.Entity<Usuario>().HasKey("Id");
            modelBuilder.Entity<Usuario>().HasKey(a => a.Id);

            modelBuilder.Entity<Usuario>().HasKey("Id", "CPF");
            modelBuilder.Entity<Usuario>().HasKey(a => new { a.Id, a.CPF });

            modelBuilder.Entity<Usuario>().HasAlternateKey("CPF", "Email");

            modelBuilder.Entity<Usuario>().HasNoKey();


            //One > 1 Propriedade de Navegação do Objeto único.
            //Many > 1 Propriedade de Navegação do tipo Lista/Colleção.
            modelBuilder.Entity<Usuario>().HasOne(usu=>usu.Contato).WithOne(cont=>cont.Usuario).HasForeignKey<Contato>(a=>a.UsuarioId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Usuario>().HasMany(usu=>usu.EnderecosEntrega).WithOne(end=>end.Usuario).HasForeignKey(end=>end.UsuarioId);
            modelBuilder.Entity<Usuario>().HasMany(usu=>usu.Departamentos).WithMany(dep=>dep.Usuarios);

            modelBuilder.Entity<Usuario>().Property(a => a.Preco).HasPrecision(2);
            #endregion

            /*
             * Pequenos/Médio > Cerca 0 - 10
             */
            #region Usuario
            modelBuilder.Entity<Usuario>();
            modelBuilder.Entity<Usuario>();
            modelBuilder.Entity<Usuario>();
            modelBuilder.Entity<Usuario>();
            modelBuilder.Entity<Usuario>();
            modelBuilder.Entity<Usuario>();
            #endregion

            #region Contato
            modelBuilder.Entity<Contato>();
            modelBuilder.Entity<Contato>();
            modelBuilder.Entity<Contato>();
            modelBuilder.Entity<Contato>();
            #endregion

            /*
             * Médio/Grande > +10 Tabelas
             */
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        }
    }
}
