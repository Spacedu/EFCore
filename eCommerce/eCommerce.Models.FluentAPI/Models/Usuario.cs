using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    /*
     * EFCore + Migration: 
     * Tabela: Usuarios
     *  Id - PK
     *  Nome - nvarchar - not null
     *  Email - nvarchar - not null
     *  Sexo - nvarchar - null
     *  CPF - nvarchar - not null
     *  ....
     */
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Sexo { get; set; }
        public string? RG { get; set; }
        public string CPF { get; set; } = null!;
        public string? Mae { get; set; }
        public string? SituacaoCadastro { get; set; }
        public DateTimeOffset DataCadastro { get; set; }

        public Contato? Contato { get; set; }
        public ICollection<EnderecoEntrega>? EnderecosEntrega { get; set; }
        public ICollection<Departamento>? Departamentos { get; set; }
    }
}
