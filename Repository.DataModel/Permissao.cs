using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.DataModel
{
    [Table("Permissao")]
    public class Permissao
    {
        public Permissao()
        {
            this.Usuarios = new HashSet<Usuario>();
            this.Perfis = new HashSet<Perfil>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int AreaId { get; set; }

        public int? PermissaoId { get; set; }

        [Required]
        [MaxLength(80)]
        public string Nome { get; set; }

        [Required]
        public int Nivel { get; set; }

        [Required]
        public int Tipo { get; set; }

        [Required]
        public int Ordem { get; set; }

        [MaxLength(80)]
        public string ControllerName { get; set; }

        [MaxLength(80)]
        public string ActionName { get; set; }

        [MaxLength(80)]
        public string PermissionName { get; set; }

        [Required]
        public bool Ativo { get; set; }

        public virtual Area Area { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }

        public virtual ICollection<Perfil> Perfis { get; set; }
    }
}
