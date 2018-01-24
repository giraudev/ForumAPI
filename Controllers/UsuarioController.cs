using System;
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
        public IEnumerable<Usuario> Listar()
        {
            return dusuario.ListarUsuario();
        }

        [HttpGet("{id}")]
        public IActionResult Listar(int id)
        {
            var rs = new JsonResult(dusuario.ListarUsuario().Where(x => x.Id == id).FirstOrDefault());
            rs.ContentType = "aplication/json";
            if (rs.Value == null)
            {
                rs.StatusCode = 204;
                rs.Value = "Não há resultado para essa pesquisa";
            }
            else
            {
                rs.StatusCode = 200;
            }

            return Json(rs);
        }


        [HttpPost]
        public IActionResult Adicionar([FromBody] Usuario usuario)
        {
            JsonResult rs;
            try
            {
                /*antes de começar o processo de envio, precisamos validar com as
                anotações do Models.Usuario
                tipo de erro:
                "Nome": ["The field Nome must be a string or array type with a minimum length of '2'."*/
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                rs = new JsonResult(dusuario.Cadastro(usuario));
                rs.ContentType = "application/json";
                if (!Convert.ToBoolean(rs.Value))
                {
                    rs.StatusCode = 404;
                    rs.Value = "Ocorreu um erro";
                }
                else
                {
                    rs.StatusCode = 200;
                }
            }
            catch (System.Exception ex)
            {
                rs = new JsonResult("");
                rs.StatusCode = 204;
                rs.ContentType = "application/json";
                rs.Value = ex.Message;

            }
            return Json(rs);
        }
    }
}