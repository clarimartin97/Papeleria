using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUPedidos
{
    public class CUListadoPrecioTotalDePedidos : ICUListadoPrecioTotalDePedidos
    {
        public IRepositorioPedidos Repo { get; set; }

        public CUListadoPrecioTotalDePedidos(IRepositorioPedidos repo)
        {
            Repo = repo;
        }

        public List<double> ListadoTotalDePedidos(List<Pedido> pedidos)
        {
            return Repo.ListadoCalcularPedidos(pedidos);
        }
    }
}
