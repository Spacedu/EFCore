using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Office.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public ICollection<Colaborador>? Colaboradores { get; set; }
    }
}
