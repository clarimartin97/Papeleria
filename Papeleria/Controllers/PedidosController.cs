using LogicaAplicacion.CasosUso;
using LogicaAplicacion.CasosUso.CUPedidos;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.ExcepcionesPropias;
using Microsoft.AspNetCore.Mvc;

namespace Papeleria.Controllers
{
    public class PedidosController : Controller
    {
        //PEDIDOS
        public ICUAlta<Pedido> CUAltaPedido { get; set; }
        public ICUBuscarPorId<Pedido> CUBuscarPedido { get; set; }
        public ICUCalcularPrecioPedido CUCalcularPrecioPedido { get; set; }
        public ICUListadoPrecioTotalDePedidos CUListadoPrecioTotalDePedidos { get; set; }
        public ICUModificar<Pedido> CUModificarPedido { get; set; }
        public ICUListadoPedidosPorFecha CUListadoPedidosPorFecha { get; set; }
        public ICUListadoPedidosAnulados CUListadoPedidosAnulados { get; set; }
        public ICUAnularPedido CUAnularPedido { get; set; }
        //CLIENTES
        public ICUBuscarPorMonto CUBuscarClientesPorPedido { get; set; }
        public ICUBuscarPorId<Cliente> CUBuscarClientePorId { get; set; }
        public ICUListado<Cliente> CUListadoClientes { get; set; }
        public ICUListadoClientesPorIds CUListadoClientesPorIds { get; set; }
        public ICUListadoClientesDePedidos CUListadoClientesDePedidos { get; set; }
        //LINEAS
        public ICUListadoLineasDePedido CUListadoLineasDePedido { get; set; }
        public ICUModificar<Linea> CUModificarLinea { get; set; }
        public ICUAlta<Linea> CUAltaLinea { get; set; }
        //ARTICULOS
        public ICUListado<Articulo> CUListadoArticulos { get; set; }
        public ICUBuscarPorId<Articulo> CUBuscarArticulo { get; set; }
        public ICUModificar<Articulo> CUModificarArticulo { get; set; }
        public ICUListadoArticulosDeLineas CUListadoArticulosDeLineas { get; set; }

        public PedidosController(ICUBuscarPorMonto cuBuscarClientesPorPedido, ICUListado<Cliente> cuListadoClientes,
                ICUListado<Articulo> cuListadoArticulos, ICUAlta<Linea> cuAltaLinea,
                ICUBuscarPorId<Articulo> cuBuscarArticulo, ICUAlta<Pedido> cuAltaPedido,
                ICUModificar<Pedido> cuModificarPedido, ICUBuscarPorId<Pedido> cuBuscarPedido,
                ICUListadoLineasDePedido cuListadoLineasDePedido, ICUModificar<Articulo> cuModificarArticulo,
                ICUCalcularPrecioPedido cuCalcularPrecioPedido, ICUListadoPrecioTotalDePedidos cuListadoPrecioTotalDePedidos,
                ICUModificar<Linea> cuModificarLinea, ICUListadoPedidosAnulados cuListadoPedidosAnulados,
                ICUBuscarPorId<Cliente> cUBuscarClientePorId, ICUListadoClientesPorIds cuListadoClientesPorIds,
                ICUListadoPedidosPorFecha cuListadoPedidosPorFecha, ICUListadoClientesDePedidos cuListadoClientesDePedidos,
                ICUListadoArticulosDeLineas cuListadoArticulosDeLineas, ICUAnularPedido cuAnularPedido)
        {
            CUBuscarPedido = cuBuscarPedido;
            CUCalcularPrecioPedido = cuCalcularPrecioPedido;
            CUListadoPedidosAnulados = cuListadoPedidosAnulados;
            CUListadoPedidosPorFecha = cuListadoPedidosPorFecha;
            CUModificarPedido = cuModificarPedido;
            CUAltaPedido = cuAltaPedido;
            CUBuscarClientesPorPedido = cuBuscarClientesPorPedido;
            CUListadoClientes = cuListadoClientes;
            CUBuscarClientePorId = cUBuscarClientePorId;
            CUListadoClientesPorIds = cuListadoClientesPorIds;
            CUAltaLinea = cuAltaLinea;
            CUListadoLineasDePedido = cuListadoLineasDePedido;
            CUModificarLinea = cuModificarLinea;
            CUListadoArticulos = cuListadoArticulos;
            CUBuscarArticulo = cuBuscarArticulo;
            CUModificarArticulo = cuModificarArticulo;
            CUListadoClientesDePedidos = cuListadoClientesDePedidos;
            CUListadoPrecioTotalDePedidos = cuListadoPrecioTotalDePedidos;
            CUListadoArticulosDeLineas = cuListadoArticulosDeLineas;
            CUAnularPedido = cuAnularPedido;
        }

        //Devuelve yy-mm-dd de una fecha (en formato string).
        static string TruncarFecha(DateTime fecha)
        {
            return fecha.Year + "-"
                + (fecha.Month < 10 ? "0" + fecha.Month : fecha.Month) + "-"
                + (fecha.Day < 10 ? "0" + fecha.Day : fecha.Day);
        }

        //Calcula el recargo del pedido
        static double CalcularRecargo(bool Tipo, DateTime FechaEntrega, float DistanciaKm)
        {
            double recargo = 0;
            if (Tipo)
            {
                recargo = 10;
                if (TruncarFecha(FechaEntrega) == TruncarFecha(DateTime.Now)) recargo = 15;
            }
            else if (DistanciaKm > 100) recargo = 5;

            return recargo;
        }

        // GET: PedidosController
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        // POST: PedidosController
        // Busca clientes por monto de pedido o por fecha de pedido.
        // Lista los pedidos anulados.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string BuscarMonto, string BuscarFecha, string ListadoPedidosAnulados, double monto, DateTime date)
        {
            //Si se busca por monto
            if (BuscarMonto != null)
            {
                if (monto <= 0)
                {
                    ViewBag.ErrorMessageMonto = "El monto debe de ser superior a 0.";
                    return View();
                }

                List<int> idClientesPorMonto = CUBuscarClientesPorPedido.BuscarPorMonto(monto);

                if (idClientesPorMonto.Count != 0)
                {
                    List<Cliente> clientes = CUListadoClientesPorIds.ObtenerListadoClientesPorIds(idClientesPorMonto);
                    return View("Clientes", clientes);
                }
                else ViewBag.ErrorMessage = "No se encontraron clientes con pedidos superiores al monto ingresado.";
            }
            //Si se busca por fecha
            else if (BuscarFecha != null)
            {
                if (date <= DateTime.MinValue || date > DateTime.Now)
                {
                    ViewBag.ErrorMessageFecha = "La fecha debe de ser correcta.";
                    return View();
                }

                List<Pedido> pedidosPorFecha = CUListadoPedidosPorFecha.ListadoPedidosPorFecha(date);

                if (pedidosPorFecha.Count != 0)
                {
                    ViewBag.Clientes = CUListadoClientesDePedidos.ListadoClientesDePedidos(pedidosPorFecha);
                    ViewBag.TotalPedidos = CUListadoPrecioTotalDePedidos.ListadoTotalDePedidos(pedidosPorFecha);

                    return View("ListadoNoEntregados", pedidosPorFecha);
                }
                else ViewBag.ErrorMessage = "No se encontraron pedidos para la fecha seleccionada.";
            }
            //Si se quiere ver el listado de pedidos anulados
            else if (ListadoPedidosAnulados != null)
                return View("Listado", CUListadoPedidosAnulados.ObtenerListadoPedidosAnuladosYNoAnulados(true));

            return View();
        }

        // GET: PedidosController/Clientes
        public IActionResult Clientes(List<Cliente> clientes)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
                return RedirectToAction("Login", "Login");

            if (clientes != null)
                return View(clientes);

            return View();
        }

        // GET: PedidosController/Create
        //Setea valores para crear un pedido nuevo o muestra las líneas de un pedido existente.
        public IActionResult Create(bool Tipo, int ClienteId, int PedidoId, DateTime FechaEntrega)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
                return RedirectToAction("Login", "Login");

            //Si ClienteId existe, es porque hay un pedido en curso que no se ha finalizado.
            if (ClienteId != 0)
            {
                Pedido pedidoExistente = CUBuscarPedido.Buscar(PedidoId);
                List<Linea> lineasDePedido = CUListadoLineasDePedido.ObtenerListadoLineasDePedido(pedidoExistente);
                List<Articulo> articulosDeLineas = CUListadoArticulosDeLineas.ListadoArticulosDeLineas(lineasDePedido);

                ViewBag.Disabled = true;
                ViewBag.TipoComun = !Tipo;
                ViewBag.TipoExpress = Tipo;
                ViewBag.MinDate = TruncarFecha(FechaEntrega);
                ViewBag.ClienteId = ClienteId;
                ViewBag.Lineas = lineasDePedido;
                ViewBag.ArticulosDeLineas = articulosDeLineas;
                ViewBag.PedidoId = PedidoId;
                ViewBag.Iva = pedidoExistente.Iva;
                ViewBag.Recargo = pedidoExistente.Recargo;
                ViewBag.Total = CUCalcularPrecioPedido.CalcularPrecioPedido(pedidoExistente);
            }
            //Si no existe ClienteId, se setean los valores por defecto.
            else
            {
                ViewBag.TipoComun = true;
                ViewBag.MinDate = TruncarFecha(DateTime.Now);
                ViewBag.ClienteId = 0;
            }

            ViewBag.Clientes = CUListadoClientes.ObtenerListado();
            ViewBag.Articulos = CUListadoArticulos.ObtenerListado();

            return View();
        }

        // POST: PedidosController/Create
        //Crea un pedido nuevo o agrega una línea a un pedido existente.
        //Finaliza un pedido existente.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string FinalizarPedido, bool Tipo, string ClienteId, string ArticuloId, string Cantidad, string PedidoId, DateTime FechaEntrega)
        {
            ViewBag.Clientes = CUListadoClientes.ObtenerListado();
            ViewBag.Articulos = CUListadoArticulos.ObtenerListado();
            ViewBag.MinDate = TruncarFecha(DateTime.Now);

            //Si se finaliza un pedido existente
            if (FinalizarPedido != null)
            {
                Pedido pedidoExistente = CUBuscarPedido.Buscar(Int32.Parse(PedidoId));

                if (pedidoExistente != null)
                {
                    Cliente c = CUBuscarClientePorId.Buscar(pedidoExistente.ClienteId);
                    double recargo = CalcularRecargo(Tipo, FechaEntrega, c.DistanciaKm);

                    pedidoExistente.Recargo = recargo;
                    CUModificarPedido.Modificar(pedidoExistente);
                }

                return RedirectToAction("Create");
            }

            Articulo articulo = CUBuscarArticulo.Buscar(Int32.Parse(ArticuloId));
            Cliente cliente = CUBuscarClientePorId.Buscar(Int32.Parse(ClienteId));

            //Validación de inputs
            if (articulo == null || cliente == null || Cantidad == null || Cantidad == "" || Int32.Parse(Cantidad) <= 0 ||
                    FechaEntrega.Date == DateTime.MinValue.Date || FechaEntrega.Date < DateTime.Now.Date)
            {
                ViewBag.ErrorMessage = "Error en los datos del pedido.";
                return View();
            }

            //Validación de fechas
            if (Tipo && FechaEntrega.Date >= DateTime.Now.AddDays(5).Date ||
                        !Tipo && FechaEntrega.Date < DateTime.Now.AddDays(7).Date)
            {
                ViewBag.ErrorMessage = Tipo ?
                    "Los pedidos Express no pueden superar los 5 días." :
                    "Los pedidos Comunes deben superar los 7 días.";

                return View();
            }

            //Validación de stock
            if (articulo.Stock > 0 && articulo.Stock - Int32.Parse(Cantidad) >= 0)
            {
                Linea linea = new Linea
                {
                    ArticuloId = articulo.Id,
                    Cantidad = Int32.Parse(Cantidad),
                    PrecioUnitario = articulo.PrecioVenta,
                    Anulado = false
                };

                CUAltaLinea.Alta(linea);

                articulo.Stock -= Int32.Parse(Cantidad);
                CUModificarArticulo.Modificar(articulo);

                //Si PedidoId existe, es porque se está agregando una línea a un pedido existente.
                if (PedidoId != null)
                {
                    Pedido pedidoExistente = CUBuscarPedido.Buscar(Int32.Parse(PedidoId));
                    if (pedidoExistente == null || pedidoExistente.ClienteId != Int32.Parse(ClienteId)) return View();

                    pedidoExistente.Lineas = [linea];
                    CUModificarPedido.Modificar(pedidoExistente);
                }
                //Si no, es porque se está creando un pedido nuevo.
                else
                {
                    double recargo = CalcularRecargo(Tipo, FechaEntrega, cliente.DistanciaKm);

                    Pedido nuevoPedido = new Pedido
                    {
                        ClienteId = cliente.Id,
                        FechaPedido = DateTime.Now,
                        FechaEntrega = FechaEntrega,
                        Tipo = Tipo,
                        Lineas = [linea],
                        Iva = 22,
                        Recargo = recargo,
                        Anulado = false
                    };

                    CUAltaPedido.Alta(nuevoPedido);

                    PedidoId = nuevoPedido.Id.ToString();
                }
            }
            //Si no hay stock suficiente
            else
            {
                ViewBag.ErrorMessage = "No hay suficiente cantidad de stock.";
                return View();
            }

            return RedirectToAction("Create", new
            {
                Tipo,
                ClienteId,
                PedidoId,
                FechaEntrega
            });
        }

        // GET: PedidosController/Delete/5
        public ActionResult Delete(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
            {
                return RedirectToAction("Login", "Login");
            }

            Pedido pedido = CUBuscarPedido.Buscar(id);
            return View(pedido);
        }

        // POST: PedidosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Pedido p)
        {
            try
            {
                Pedido pedidoAAnular = CUBuscarPedido.Buscar(id);
                List<Linea> lineasDePedido = CUListadoLineasDePedido.ObtenerListadoLineasDePedido(pedidoAAnular);
                CUAnularPedido.AnularPedido(lineasDePedido, pedidoAAnular);

                return RedirectToAction(nameof(Listado));
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

        // GET: PedidosController/Listado
        public IActionResult Listado(List<Pedido> pedidos)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
                return RedirectToAction("Login", "Login");

            if (pedidos.Count == 0)
            {
                pedidos = CUListadoPedidosAnulados.ObtenerListadoPedidosAnuladosYNoAnulados(false);
                ViewBag.Anulados = false;
            }
            else ViewBag.Anulados = true;

            return View(pedidos);
        }

        // GET: PedidosController/ListadoNoEntregados
        public IActionResult ListadoNoEntregados(List<Pedido> pedidos)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
                return RedirectToAction("Login", "Login");

            return View(pedidos);
        }
    }
}
