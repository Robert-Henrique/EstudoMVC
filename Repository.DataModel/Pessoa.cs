using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.DataModel
{
    [Table("Pessoa")]
    public class Pessoa
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(18)]
        public string CPF_CNPJ { get; set; }

        [Required]
        [MaxLength(1)]
        public string Genero { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
    }
}
