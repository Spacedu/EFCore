using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Office.Models
{
    public class ColaboradorSetor
    {
        public int ColaboradorId { get; set; }
        public int SetorId { get; set; }
        public Colaborador Colaborador { get; set; } = null!;
        public Setor Setor { get; set; } = null!;
    }
}
