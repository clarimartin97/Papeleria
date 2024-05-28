using DTOs;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.ExcepcionesPropias;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papeleria.Models;
using System.Security.Cryptography;
using System.Text;

namespace Papeleria.Controllers
{
    public class UsuariosController : Controller
    {
        public ICUAlta<DTOAltaUsuario> CUAlta { get; set; }
        public ICUBuscarPorId<Usuario> CUBuscar { get; set; }
        public ICUModificar<Usuario> CUModificar { get; set; }
        public ICUListado<DTOUsuarioSimple> CUListadoUsuarios { get; set; }
        public ICUBaja<Usuario> CUBaja { get; set; }

        public UsuariosController(ICUAlta<DTOAltaUsuario> cuAlta, ICUListado<DTOUsuarioSimple> cuListadoUsuarios,
                                    ICUBuscarPorId<Usuario> cuBuscar, ICUModificar<Usuario> cuModificar,
                                    ICUBaja<Usuario> cUBajaUsuario)
        {
            CUAlta = cuAlta;
            CUListadoUsuarios = cuListadoUsuarios;
            CUBuscar = cuBuscar;
            CUModificar = cuModificar;
            CUBaja = cUBajaUsuario;
        }

        //Método para encriptar la contraseña
        static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convertir la contraseña en un arreglo de bytes
                byte[] bytes = Encoding.UTF8.GetBytes(password);

                // Calcular el hash
                byte[] hash = sha256.ComputeHash(bytes);

                // Convertir el hash de bytes a una cadena hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                    builder.Append(hash[i].ToString("x2"));

                return builder.ToString();
            }
        }

        // GET: UsuariosController
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
                return RedirectToAction("Login", "Login");

            List<DTOUsuarioSimple> usuarios = CUListadoUsuarios.ObtenerListado();
            return View(usuarios);
        }

        // GET: UsuariosController/Details/5
        public ActionResult Details(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
                return RedirectToAction("Login", "Login");

            Usuario u = CUBuscar.Buscar(id);
            return View(u);
        }

        // GET: UsuariosController/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
                return RedirectToAction("Login", "Login");

            return View();
        }

        // POST: UsuariosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AltaUsuarioViewModel vm)
        {
            try
            {
                CUAlta.Alta(new DTOAltaUsuario()
                {
                    Email = vm.Email,
                    Nombre = vm.Nombre,
                    Apellido = vm.Apellido,
                    Contrasenia = vm.Contrasenia,
                    ContraseniaEncriptada = HashPassword(vm.Contrasenia)
                });
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

            return View(vm);
        }

        // GET: UsuariosController/Edit/5
        public ActionResult Edit(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
                return RedirectToAction("Login", "Login");

            Usuario u = CUBuscar.Buscar(id);

            return View(u);
        }

        // POST: UsuariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Usuario user)
        {
            try
            {
                Usuario u = CUBuscar.Buscar(id);
                u.Nombre = user.Nombre;
                u.Apellido = user.Apellido;
                u.Contrasenia = user.Contrasenia;
                u.ContraseniaEncriptada = HashPassword(user.Contrasenia);

                CUModificar.Modificar(u);
                return RedirectToAction(nameof(Index));
            }
            catch (DatosInvalidosException e)
            {
                ViewBag.Mensaje = e.Message;
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Ocurrió un error, no se pudo realizar la modificación";
            }

            return View();
        }

        // GET: UsuariosController/Delete/5
        public ActionResult Delete(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
                return RedirectToAction("Login", "Login");

            Usuario u = CUBuscar.Buscar(id);
            return View(u);
        }

        // POST: UsuariosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Usuario u)
        {
            try
            {
                CUBaja.Baja(id);
                return RedirectToAction(nameof(Index));
            }
            catch (DatosInvalidosException e)
            {
                ViewBag.Mensaje = e.Message;
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Ocurrió un error, no se pudo realizar la eliminación.";
            }

            return View();
        }
    }
}
