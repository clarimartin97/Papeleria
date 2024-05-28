using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace Papeleria.Controllers
{
    public class ClientesController : Controller
    {
        public ICUBuscarPorId<Cliente> CUBuscar { get; set; }
        public ICUBuscarClientePorRazonSocialYRut CUBuscarRR { get; set; }

        public ClientesController(ICUBuscarPorId<Cliente> cuBuscar,
                                    ICUBuscarClientePorRazonSocialYRut cuBuscarRR)
        {
            CUBuscar = cuBuscar;
            CUBuscarRR = cuBuscarRR;
        }

        // GET: ClientesController
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
                return RedirectToAction("Login", "Login");

            return View();
        }

        // POST: ClientesController
        // Busca un cliente por su razón social y su rut.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string RazonSocial, string Rut)
        {
            try
            {
                if (string.IsNullOrEmpty(RazonSocial) || string.IsNullOrEmpty(Rut))
                    ViewBag.ErrorMessage = "Debe ingresar un valor en ambos campos";
                else
                {
                    Cliente c = CUBuscarRR.BuscarClientePorRazonSocialYRut(RazonSocial, Rut);
                    if (c != null)
                        return RedirectToAction("Details", new { id = c.Id });

                    ViewBag.ErrorMessage = "No se encontró el cliente";
                }
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Ocurrió un error inesperado. No se encontró el cliente.";
            }

            return View();
        }

        //GET: ClientesController/Details/5
        public ActionResult Details(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
                return RedirectToAction("Login", "Login");

            Cliente c = CUBuscar.Buscar(id);
            if (c == null)
                return RedirectToAction("Index");

            return View(c);
        }
    }
}
