using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioPedidos : IRepositorio<Pedido>
    {
        public List<int> BuscarPorMonto(double monto);
        public double CalcularPrecio(Pedido pedido);
        public List<double> ListadoCalcularPedidos(List<Pedido> pedidos);
        public List<Pedido> FindAllPorFecha(DateTime fecha);
        public List<Pedido> ListadoPedidosAnuladosYNoAnulados(bool anulados);
        public void AnularPedido(List<Linea> lineas, Pedido pedido);
    }
}
