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
    public class CUListadoClientesDePedidos : ICUListadoClientesDePedidos
    {
        public IRepositorioClientes Repo { get; set; }

        public CUListadoClientesDePedidos(IRepositorioClientes repo)
        {
            Repo = repo;
        }

        public List<Cliente> ListadoClientesDePedidos(List<Pedido> pedidos)
        {
            return Repo.ListadoClientesPedidos(pedidos);
        }
    }
}
