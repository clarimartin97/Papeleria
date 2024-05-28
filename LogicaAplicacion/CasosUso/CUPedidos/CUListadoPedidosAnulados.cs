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
    public class CUListadoPedidosAnulados : ICUListadoPedidosAnulados
    {
        public IRepositorioPedidos Repo { get; set; }

        public CUListadoPedidosAnulados(IRepositorioPedidos repo)
        {
            Repo = repo;
        }

        public List<Pedido> ObtenerListadoPedidosAnuladosYNoAnulados(bool anulados)
        {
            return Repo.ListadoPedidosAnuladosYNoAnulados(anulados);
        }
    }
}
