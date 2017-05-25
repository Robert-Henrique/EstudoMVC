using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.DataModel
{
    [Table("Usuario")]
    public class Usuario
    {
        public Usuario()
        {
            this.Permissoes = new HashSet<Permissao>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int PessoaId { get; set; }

        [Required]
        public int PerfilId { get; set; }

        [Required]
        [MaxLength(80)]
        public string Login { get; set; }

        [Required]
        public bool Administrador { get; set; }

        [Required]
        public bool Ativo { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        public virtual ICollection<Permissao> Permissoes { get; set; }
    }
}
