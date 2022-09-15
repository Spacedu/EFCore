using System;
using System.Collections.Generic;

namespace eCommerce.Console.Models
{
    public partial class EnderecosEntrega
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string NomeEndereco { get; set; } = null!;
        public string Cep { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string Cidade { get; set; } = null!;
        public string Bairro { get; set; } = null!;
        public string Endereco { get; set; } = null!;
        public string? Numero { get; set; }
        public string? Complemento { get; set; }

        public virtual Usuario Usuario { get; set; } = null!;
    }
}
