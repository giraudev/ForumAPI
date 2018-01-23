using System.Data.SqlClient;

namespace ForumApi.Models
{
    public abstract class Conexao
    {
        /// <summary>
        /// Objeto utilizado para estabelecer a conexão com o servidor do banco de dados SQL Express
        /// </summary>
        protected SqlConnection con = null;

        /// <summary>
        /// Objeto utilizado para executar comandos de SQL tais como:
        /// Select, Update, Delete, Insert e Outros
        /// </summary>
        protected SqlCommand cmd = null;

        /// <summary>
        /// Objeto utilizado para guardar os retornos do select realizado
        /// nas tabelas do bacnod e dados.
        /// </summary>
        protected SqlDataReader sdr = null;
        
        /// <summary>
        /// Este método retorna o local do banco de dados.
        /// </summary>
        /// <returns>Retorna uma string de conexão com o banco</returns>
        protected static string Caminho(){
            return @"Data Source=.\SqlExpress;initial catalog=forum;user id=sa; password=senai@123";
        }

    }
}