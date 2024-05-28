using DTOs;
using LogicaAplicacion.CasosUso.CUArticulos;
using LogicaAplicacion.CasosUso.CUClientes;
using LogicaAplicacion.CasosUso.CULineas;
using LogicaAplicacion.CasosUso.CUPedidos;
using LogicaAplicacion.CasosUso.CUUsuarios;
using LogicaAplicacion.InterfacesCU;
using LogicaDatos.Repositorios;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;

namespace Papeleria
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Usuarios
            builder.Services.AddScoped<ICUAlta<DTOAltaUsuario>, CUAltaUsuario>();
            builder.Services.AddScoped<ICUBuscarPorId<Usuario>, CUBuscarUsuarioPorId>();
            builder.Services.AddScoped<ICUModificar<Usuario>, CUModificarUsuario>();
            builder.Services.AddScoped<ICUListado<DTOUsuarioSimple>, CUListadoUsuariosSimple>();
            builder.Services.AddScoped<ICUBaja<Usuario>, CUBajaUsuario>();
            builder.Services.AddScoped<ICULoginUsuarios, CULoginUsuarios>();

            //Articulos
            builder.Services.AddScoped<ICUAlta<Articulo>, CUAltaArticulo>();
            builder.Services.AddScoped<ICUBuscarPorId<Articulo>, CUBuscarArticuloPorId>();
            builder.Services.AddScoped<ICUModificar<Articulo>, CUModificarArticulo>();
            builder.Services.AddScoped<ICUListado<Articulo>, CUListadoArticulos>();
            builder.Services.AddScoped<ICUListadoArticulosOrdenado, CUListadoArticulosOrdenado>();
            builder.Services.AddScoped<ICUListadoArticulosDeLineas, CUListadoArticulosDeLineas>();

            //Pedidos
            builder.Services.AddScoped<ICUAlta<Pedido>, CUAltaPedido>();
            builder.Services.AddScoped<ICUBuscarPorId<Pedido>, CUBuscarPedidoPorId>();
            builder.Services.AddScoped<ICUModificar<Pedido>, CUModificarPedido>();
            builder.Services.AddScoped<ICUListadoPedidosPorFecha, CUListadoPedidosPorFecha>();
            builder.Services.AddScoped<ICUListadoPedidosAnulados, CUListadoPedidosAnulados>();
            //Pedidos que devuelven clientes
            builder.Services.AddScoped<ICUBuscarPorMonto, CUBuscarPorMonto>();
            builder.Services.AddScoped<ICUCalcularPrecioPedido, CUCalcularPrecioPedido>();
            builder.Services.AddScoped<ICUListadoPrecioTotalDePedidos, CUListadoPrecioTotalDePedidos>();
            builder.Services.AddScoped<ICUAnularPedido, CUAnularPedido>();

            //Clientes
            builder.Services.AddScoped<ICUBuscarPorId<Cliente>, CUBuscarClientePorId>();
            builder.Services.AddScoped<ICUBuscarClientePorRazonSocialYRut, CUBuscarClientePorRazonSocialYRut>();
            builder.Services.AddScoped<ICUListado<Cliente>, CUListadoClientes>();
            builder.Services.AddScoped<ICUListadoClientesPorIds, CUListadoClientesPorIds>();
            builder.Services.AddScoped<ICUListadoClientesDePedidos, CUListadoClientesDePedidos>();

            //Lineas
            builder.Services.AddScoped<ICUAlta<Linea>, CUAltaLinea>();
            builder.Services.AddScoped<ICUListadoLineasDePedido, CUListadoLineasDePedido>();
            builder.Services.AddScoped<ICUModificar<Linea>, CUModificarLinea>();

            //Repositorios EF
            builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuariosEF>();
            builder.Services.AddScoped<IRepositorioArticulos, RepositorioArticulosEF>();
            builder.Services.AddScoped<IRepositorioClientes, RepositorioClientesEF>();
            builder.Services.AddScoped<IRepositorioDirecciones, RepositorioDireccionesEF>();
            builder.Services.AddScoped<IRepositorioLineas, RepositorioLineasEF>();
            builder.Services.AddScoped<IRepositorioPedidos, RepositorioPedidosEF>();

            builder.Services.AddSession();

            builder.Services.AddDbContext<LibreriaContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Usuarios}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
