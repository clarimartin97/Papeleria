using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.ExcepcionesPropias;
using Microsoft.AspNetCore.Mvc;

namespace Papeleria.Controllers
{
    public class ArticulosController : Controller
    {
        public ICUAlta<Articulo> CUAlta { get; set; }
        public ArticulosController(ICUAlta<Articulo> cuAlta)
        {
            CUAlta = cuAlta;
        }

        // GET: ArticulosController
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
            {
                return RedirectToAction("Login", "Login");
            }

            //se van a ver todos los articulos en algun momento

            return View();
        }

        // GET: ArticulosController/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
                return RedirectToAction("Login", "Login");

            return View();
        }

        // POST: ArticulosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Articulo nuevo)
        {
            try
            {
                CUAlta.Alta(nuevo);
                return RedirectToAction(nameof(Index));
            }
            catch (DatosInvalidosException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Ocurrió un error inesperado. No se hizo el alta de usuario.";
            }

            return View(nuevo);
        }
    }
}
