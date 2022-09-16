using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    /*
     * Usuario -> Pedido
     * Usuario (Clientes e Colaborador)
     * Pedido:
     * - Fazer Pedido (Usuario-Cliente)
     * - Atualizar o Pedido (Usuario-Colaborador)
     * - Supervisionar o pedido (Usuario-Colaborador-Supervisor)
     */

    /*
     * Schema:
     * *[Table] = Definir o nome da tabela
     * *[Column] = Definir o nome da coluna
     * *[NotMapped] = Não mapear uma propriedade
     * *[ForeignKey] = Definir que a propriedade é o vinculo da chave estrangeira
     * *[InverseProperty] = Defini a referência para cada FK vinda da mesma tabela.
     * *[DatabaseGenerated] = Definir se uma propriedade vai ou não ser gerenciada pelo banco.
     * 
     * DataAnnotations:
     * *[Key] = Definir que a propriedade é uma PK.
     * 
     * EF Core
     * *[Index] = Definir/Criar Indice no banco (Unique).
     */

    /*
     * DataAnnotation, FluentAPI:
     * Code-First = Code -> Database
     * Database-First = Database -> Code
     */

    //nameof(Email) = "Email"
    [Index(nameof(Email), IsUnique = true, Name = "IX_EMAIL_UNICO")]
    [Index(nameof(Nome), nameof(CPF))]
    [Table("TB_USUARIOS")]
    public class Usuario
    {
        /*Convensão Id - UsuarioId = PK - Identity*/
        
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        /*
        [Key]
        [Column("COD")]
        public int Codigo { get; set; }
        */
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(15)]
        public string? Sexo { get; set; }

        [Column("REGISTRO_GERAL")]
        public string? RG { get; set; }
        public string CPF { get; set; } = null!;
        public string? Mae { get; set; }
        public string? SituacaoCadastro { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Matricula { get; set; }
        /*
         * Software/Aplicativo - Não persistido.
         * RegistroAtivo = (SituacaoCadastro == "ATIVO") ? true : false;
         */
        [NotMapped]
        public bool RegistroAtivo { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTimeOffset DataCadastro { get; set; } // "GETDATE()"
        [ForeignKey("UsuarioId")]
        public Contato? Contato { get; set; }
        public ICollection<EnderecoEntrega>? EnderecosEntrega { get; set; }
        public ICollection<Departamento>? Departamentos { get; set; }

        /*
         * PedidosCompradosPeloCliente 
         * - ClienteId*
         * - ColaboradorId
         * - SupervisorId
         * 
         * PedidosGerenciadoPeloColaborador
         * - ClienteId
         * - ColaboradorId*
         * - SupervisorId
         * 
         * PedidosSupervisionadosPeloColaboradorSupervisor
         * - ClienteId
         * - ColaboradorId
         * - SupervisorId*
         */

        [InverseProperty("Cliente")]
        public ICollection<Pedido>? PedidosCompradosPeloCliente { get; set; }

        [InverseProperty("Colaborador")]
        public ICollection<Pedido>? PedidosGerenciadoPeloColaborador { get; set; }

        [InverseProperty("Supervisor")]
        public ICollection<Pedido>? PedidosSupervisionadosPeloColaboradorSupervisor { get; set; }
    }
}
