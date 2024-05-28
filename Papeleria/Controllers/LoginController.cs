using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Papeleria.Controllers
{
    public class LoginController : Controller
    {
        public ICULoginUsuarios CULogin { get; set; }
        public LoginController(ICULoginUsuarios cuLogin)
        {
            CULogin = cuLogin;
        }

        // GET: LoginController
        public IActionResult Login()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
                return View();

            return RedirectToAction("Index", "Usuarios");
        }

        // POST: LoginController
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string Email, string Contrasenia)
        {
            try
            {
                Usuario user = CULogin.Login(Email, Contrasenia);
                if (user != null)
                {
                    HttpContext.Session.SetString("user", Email);
                    ViewBag.Message = null;
                    return RedirectToAction("Index", "Usuarios");
                }
                else ViewBag.Message = "Email o Contraseña incorrectos";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Login");
        }
    }
}
