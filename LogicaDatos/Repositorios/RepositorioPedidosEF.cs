using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioPedidosEF : IRepositorioPedidos
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioPedidosEF(LibreriaContext ctx)
        {
            Contexto = ctx;
        }

        //Agrega un nuevo pedido.
        public void Add(Pedido nuevo)
        {
            nuevo.Validar();

            Contexto.Pedidos.Add(nuevo);
            Contexto.SaveChanges();
        }

        //Devuelve una lista con todos los pedidos.
        public List<Pedido> FindAll()
        {
            return Contexto.Pedidos.ToList();
        }

        //Devuelve un pedido por su id.
        public Pedido FindById(int id)
        {
            return Contexto.Pedidos.Find(id);
        }

        //Elimina un pedido por su id.
        public void Remove(int id)
        {
            Pedido? aBorrar = Contexto.Pedidos.Find(id) ?? throw new Exception("No se encontró el pedido");
            Contexto.Pedidos.Remove(aBorrar);
            Contexto.SaveChanges();
        }

        //Actualiza un pedido.
        public void Update(Pedido obj)
        {
            obj.Validar();
            Contexto.Update(obj);
            Contexto.SaveChanges();
        }

        //Devuelve una lista de enteros con los id de los clientes que han realizado un pedido con un monto mayor al pasado por parámetro.
        public List<int> BuscarPorMonto(double monto)
        {
            return Contexto.Pedidos
                .Include(pedido => pedido.Lineas)
                .Where(p => p.Lineas
                    .Sum(l => l.PrecioUnitario * l.Cantidad)
                        * (1 + (p.Recargo / 100))
                        * (1 + (p.Iva / 100))
                        > monto
                )
                .Select(pedido => pedido.ClienteId)
                .ToList();
        }

        //Devuelve un double con el precio total de un pedido.
        public double CalcularPrecio(Pedido pedido)
        {
            return Contexto.Pedidos
                .Include(p => p.Lineas)
                .Where(p => p.Id == pedido.Id)
                .Select(p => Math.Round(p.Lineas
                    .Sum(l => l.PrecioUnitario * l.Cantidad)
                        * (1 + (p.Recargo / 100))
                        * (1 + (p.Iva / 100))
                    , 2)
                )
                .FirstOrDefault();
        }

        //Devuelve una lista de pedidos cuando FechaPedido = fecha.
        public List<Pedido> FindAllPorFecha(DateTime fecha)
        {
            return Contexto.Pedidos
                .Where(p => p.FechaPedido.Date == fecha.Date && DateTime.Now.Date < p.FechaEntrega.Date)
                .ToList();
        }

        //Devuelve una lista de pedidos anulados ordenados de manera descendentemente y no anulados (dependiendo del valor de anulados).
        public List<Pedido> ListadoPedidosAnuladosYNoAnulados(bool anulados)
        {
            return anulados
                ? Contexto.Pedidos
                    .Where(p => p.Anulado)
                    .OrderByDescending(p => p.FechaPedido)
                    .ToList()
                : Contexto.Pedidos
                    .Where(p => !p.Anulado)
                    .ToList();
        }

        //Devuelve una lista de doubles con el precio total de los pedidos.
        public List<double> ListadoCalcularPedidos(List<Pedido> pedidos)
        {
            return Contexto.Pedidos
                .Include(p => p.Lineas)
                .Where(p => pedidos.Contains(p))
                .Select(p => Math.Round(p.Lineas
                    .Sum(l => l.PrecioUnitario * l.Cantidad)
                        * (1 + (p.Recargo / 100))
                        * (1 + (p.Iva / 100))
                    , 2)
                )
                .ToList();
        }

        public void AnularPedido(List<Linea> lineas, Pedido pedido)
        {
            Contexto.Articulos
                .Where(articulo => lineas.Select(linea => linea.ArticuloId).Contains(articulo.Id))
                .ToList()
                .ForEach(articulo =>
                {
                    Linea? linea = lineas.FirstOrDefault(l => l.ArticuloId == articulo.Id);
                    if (linea != null)
                    {
                        articulo.Stock += linea.Cantidad;
                        linea.Anulado = true;
                        Contexto.Update(articulo);
                        Contexto.Update(linea);
                    }
                });

            pedido.Anulado = true;
            Contexto.Update(pedido);
            Contexto.SaveChanges();
        }
    }
}
