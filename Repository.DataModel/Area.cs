﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.DataModel
{
    [Table("Area")]
    public class Area
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Nome { get; set; }

        [Required]
        public bool Ativo { get; set; }
    }
}
