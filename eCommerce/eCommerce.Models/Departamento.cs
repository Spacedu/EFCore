using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string? Nome { get; set; }

        public ICollection<Usuario>? Usuarios { get; set; }
    }
}
