using System;
using System.ComponentModel.DataAnnotations;

namespace ForumApi.Models
{
    public class Topico
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(10)]
        public string Titulo { get; set; }

        [Required]
        [MinLength(14)]
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}