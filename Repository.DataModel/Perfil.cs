using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.DataModel
{
    [Table("Perfil")]
    public class Perfil
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
