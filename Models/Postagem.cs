using System;
using System.ComponentModel.DataAnnotations;

namespace ForumApi.Models
{
    public class Postagem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdTopico { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        [MinLength(10)]
        public string Mensagem { get; set; }
        public DateTime DataPublicacao { get; set; }
    }
}