using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ForumApi.Models
{
    public class DAOUsuario : Conexao
    {
        public bool Cadastro(Usuario usuario){
            bool retorno = false;

            try{
                con = new SqlConnection();
                cmd = new SqlCommand();
                string inserir = "INSERT INTO usuario (nome, login, senha, datacadastro) VALUES ('"+usuario.Nome+"','"+usuario.Login+"','"+usuario.Senha+"', GETDATE())";
                con.ConnectionString = Caminho();
                con.Open();
                cmd.Connection = con;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = inserir;

                int rs = cmd.ExecuteNonQuery();
                
                if(rs > 0)
                    retorno = true;
                
            }catch(SqlException se){
                throw new Exception("Erro ao tentar cadastrar ->"+se.Message);
            }catch(Exception e){
                throw new Exception("Erro inesperado ->"+e.Message);
            }finally{
                con.Close();
            }

            return retorno;
        }

        public bool Atualizar(Usuario usuario){
            bool retorno = false;

            try{
                con = new SqlConnection();
                cmd = new SqlCommand();
                string atualizar = "UPDATE usuario SET nome='"+usuario.Nome+"', login='"+usuario.Login+"', senha='"+usuario.Senha+"', datacadastro=GETDATE() WHERE id="+usuario.Id+"";
                con.ConnectionString = Caminho();
                con.Open();
                cmd.Connection = con;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = atualizar;

                int rs = cmd.ExecuteNonQuery();
                
                if(rs > 0)
                    retorno = true;
                
            }catch(SqlException se){
                throw new Exception("Erro ao tentar atualizar ->"+se.Message);
            }catch(Exception e){
                throw new Exception("Erro inesperado ->"+e.Message);
            }finally{
                con.Close();
            }

            return retorno;
        }

        public bool Apagar(int id){
            bool retorno = false;

            try{
                con = new SqlConnection();
                cmd = new SqlCommand();
                string deletar = "DELETE FROM usuario WHERE id="+id+"";
                con.ConnectionString = Caminho();
                con.Open();
                cmd.Connection = con;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = deletar;

                int rs = cmd.ExecuteNonQuery();
                
                if(rs > 0)
                    retorno = true;
                
            }catch(SqlException se){
                throw new Exception("Erro ao tentar deletar ->"+se.Message);
            }catch(Exception e){
                throw new Exception("Erro inesperado ->"+e.Message);
            }finally{
                con.Close();
            }

            return retorno;
        }

        public List<Usuario> ListarUsuario(){
            List<Usuario> lstUsuario = new List<Usuario>();

            try{
                con = new SqlConnection(Caminho());
                con.Open();
                cmd = new SqlCommand("SELECT * FROM usuario", con);
                sdr = cmd.ExecuteReader();

                while(sdr.Read()){
                    lstUsuario.Add(new Usuario(){
                        Id           = sdr.GetInt32(0),
                        Nome         = sdr.GetString(1),
                        Login        = sdr.GetString(2),
                        Senha        = sdr.GetString(3),
                        DataCadastro = sdr.GetDateTime(4)
                    });
                }
                
            }catch(SqlException se){
                    throw new Exception("Erro ao tentar ler a tabela usuário " + se.Message);
            }catch(Exception ex){
                    throw new Exception("Erro inesperado " + ex.Message);
            }finally{
                con.Close();
            }
            return lstUsuario;

        }

    }
}