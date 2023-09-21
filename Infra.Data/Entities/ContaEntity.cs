using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Data.Entities
{
    [Table("Contas", Schema = "dbo")]
    public class ContaEntity
    {
        [Key]
        [MaxLength(10)]
        public string Nome { get; set; }

        [MaxLength(50)]
        public string Descricao { get; set; }

        public ContaEntity() { }

        public ContaEntity(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }
    }
}