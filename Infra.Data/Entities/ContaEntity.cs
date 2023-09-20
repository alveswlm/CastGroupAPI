using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Data.Entities
{
    [Table("Contas", Schema = "dbo")]
    [Keyless]
    public class ContaEntity
    {
        [MaxLength(30)]
        public string Nome { get; set; }

        [MaxLength(50)]
        public string Descricao { get; set; }
    }
}