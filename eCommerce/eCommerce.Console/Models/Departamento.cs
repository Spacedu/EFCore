using System;
using System.Collections.Generic;

namespace eCommerce.Console.Models
{
    public partial class Departamento
    {
        public Departamento()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
