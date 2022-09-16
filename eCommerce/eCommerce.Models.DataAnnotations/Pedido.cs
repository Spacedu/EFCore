using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    //Pedido.Cliente.Nome
    public class Pedido
    {
        public int Id { get; set; }

        
        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }


        [ForeignKey("Colaborador")]
        public int ColaboradorId { get; set; }


        [ForeignKey("Supervisor")]
        public int SupervisorId { get; set; }

        public Usuario? Cliente { get; set; }
        public Usuario? Colaborador { get; set; }
        public Usuario? Supervisor { get; set; }


    }
}
