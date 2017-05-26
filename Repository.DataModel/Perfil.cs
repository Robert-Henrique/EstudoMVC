using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.DataModel
{
    [Table("Perfil")]
    public class Perfil
    {
        public Perfil()
        {
            this.Perfis = new HashSet<Perfil>();
            this.Usuarios = new HashSet<Usuario>();
            this.Permissoes = new HashSet<Permissao>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? PerfilId { get; set; }

        [Required]
        [MaxLength(80)]
        public string Nome { get; set; }

        [Required]
        public bool Ativo { get; set; }

        public virtual ICollection<Perfil> Perfis { get; set; }
        
        public virtual Perfil Parent { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<Permissao> Permissoes { get; set; }
    }
}
