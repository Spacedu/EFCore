using System;
using System.Collections.Generic;

namespace eCommerce.Console.Models
{
    public partial class Contato
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string? Telefone { get; set; }
        public string? Celular { get; set; }

        public virtual Usuario Usuario { get; set; } = null!;
    }
}
