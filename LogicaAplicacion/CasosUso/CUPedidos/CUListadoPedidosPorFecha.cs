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
    public class CUListadoPedidosPorFecha : ICUListadoPedidosPorFecha
    {
        public IRepositorioPedidos Repo { get; set; }

        public CUListadoPedidosPorFecha(IRepositorioPedidos repo)
        {
            Repo = repo;
        }

        public List<Pedido> ListadoPedidosPorFecha(DateTime fecha)
        {
            return Repo.FindAllPorFecha(fecha);
        }
    }
}
