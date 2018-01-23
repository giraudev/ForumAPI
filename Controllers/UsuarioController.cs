using System.Collections.Generic;
using System.Linq;
using ForumApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumApi.Controllers
{
    [Route("usuario")]
    public class UsuarioController : Controller
    {
        DAOUsuario dusuario = new DAOUsuario();

        [HttpGet]
        public IEnumerable<Usuario> Listar(){
            return dusuario.ListarUsuario();
        }

        [HttpGet("{id}")]
        public IActionResult Listar(int id){
            var rs = new JsonResult(dusuario.ListarUsuario().Where(x => x.Id == id).FirstOrDefault());
            rs.ContentType = "aplication/json";
            if(rs.Value == null){
                rs.StatusCode = 204;
                rs.Value = "Não há resultado para essa pesquisa";
            }else{
                rs.StatusCode = 200; 
            }
            
            return Json(rs);
        }


        [HttpPost]
        public void Adicionar([FromBody] Usuario usuario){
            dusuario.Cadastro(usuario);
        }

    }
}