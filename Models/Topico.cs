using System;

namespace ForumApi.Models
{
    public class Topico
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}