using System.Collections.Generic;
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

        
    }
}