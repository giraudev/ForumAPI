using System;
//importar datatanotations
using System.ComponentModel.DataAnnotations;

namespace ForumApi.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        //forma como a coluna será apresentada
        [Display(Name="Nome do Usuario")]

        /*para dizer que o dado é requerido
        se der erro, mostrará mensagem*/
        [Required(ErrorMessage="Este campo não pode ficar vazio")]

        /*especificar a qntde minima dentro da caixa
        2: quantidade
        , error: mensagem de erro*/
        [MinLength(2,ErrorMessage="Você deve inserir um nome com mais de 2 caracteres")]

        //maximo de dados, ou podemos usar [StringLength]
        [MaxLength(10,ErrorMessage="Você não tem um nome tão grande, mentiroso")]

        public string Nome { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(8)]
        public string Login { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(12)]
        [RegularExpression(@"^[a-zA-Z'\s]{1,40}$", ErrorMessage="Você não pode adicionar caracter especial")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}