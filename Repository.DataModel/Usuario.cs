using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.DataModel
{
    [Table("Usuario")]
    public class Usuario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
