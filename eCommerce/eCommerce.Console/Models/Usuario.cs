using System;
using System.Collections.Generic;

namespace eCommerce.Console.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            EnderecosEntregas = new HashSet<EnderecosEntrega>();
            Departamentos = new HashSet<Departamento>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Sexo { get; set; }
        public string? Rg { get; set; }
        public string Cpf { get; set; } = null!;
        public string? NomeMae { get; set; }
        public string? SituacaoCadastro { get; set; }
        public DateTimeOffset DataCadastro { get; set; }
        public string? NomePai { get; set; }

        public virtual Contato? Contato { get; set; }
        public virtual ICollection<EnderecosEntrega> EnderecosEntregas { get; set; }

        public virtual ICollection<Departamento> Departamentos { get; set; }
    }
}
