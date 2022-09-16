using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    /*
     * Schema:
     * [Table] = Definir o nome da tabela
     * [Column] = Definir o nome da coluna
     * [NotMapped] = Não mapear uma propriedade
     * [ForeignKey] = Definir que a propriedade é o vinculo da chave estrangeira
     * [InverseProperty] = Defini a referência para cada FK vinda da mesma tabela.
     * [DatabaseGenerated] = Definir se uma propriedade vai ou não ser gerenciada pelo banco.
     * 
     * DataAnnotations:
     * [Key] = Definir que a propriedade é uma PK.
     * 
     * EF Core
     * [Index] = Definir/Criar Indice no banco (Unique).
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
