
using LogicaAplicacion.CasosUso.CUArticulos;
using LogicaAplicacion.CasosUso.CUPedidos;
using LogicaAplicacion.InterfacesCU;
using LogicaDatos.Repositorios;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;

namespace WEBAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //articulos
            builder.Services.AddScoped<ICUListado<Articulo>, CUListadoArticulos>();
            builder.Services.AddScoped<ICUListadoArticulosOrdenado, CUListadoArticulosOrdenado>();
            //pedidos
            builder.Services.AddScoped<ICUListadoPedidosAnulados, CUListadoPedidosAnulados>();

            builder.Services.AddScoped<IRepositorioArticulos, RepositorioArticulosEF>();
            builder.Services.AddScoped<IRepositorioPedidos, RepositorioPedidosEF>();

            builder.Services.AddDbContext<LibreriaContext>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
