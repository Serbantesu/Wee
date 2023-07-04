using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        private IConfiguration _configuration;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        public UsuarioController(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(ML.Usuario usuario, string password) 
        {
            var bcrypt = new Rfc2898DeriveBytes(password, new byte[20], 10000, HashAlgorithmName.SHA256);
            //Obtener el hash de la contraseña ingresada 
            var passwordHash = bcrypt.GetBytes(20);

            if (usuario.Nombre != null)
            {
                usuario.Password = passwordHash;

                using (var client = new HttpClient())
                {
                    string urlApi = _configuration["UrlApi"];
                    client.BaseAddress = new Uri(urlApi);

                    var responseTask = client.PostAsJsonAsync<ML.Usuario>("Usuario/Add", usuario);
                    responseTask.Wait();

                    var result = responseTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Se a insertado correctamente el Usuario";
                        return View("Modal");
                    } 
                }                    
            }
            else
            {
                
                if (usuario.Password.SequenceEqual(passwordHash))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "El Correo o contraseña son incorrectos";
                    return View("Modal");
                }
            }
            return View(usuario);
        }

    }
}
