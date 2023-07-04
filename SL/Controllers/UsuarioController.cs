using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpPost]
        [Route("/api/Usuario/Add")]
        public IActionResult Add([FromBody] ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.UsuarioAdd(usuario);
            if (result.Correct)
            {
                return Ok(result); 
            }
            else
            {
                return NotFound(result.ErrorMessage);
            }            
        }
    }
}
