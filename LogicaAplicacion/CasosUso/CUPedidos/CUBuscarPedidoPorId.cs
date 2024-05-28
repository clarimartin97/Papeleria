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
    public class CUBuscarPedidoPorId : ICUBuscarPorId<Pedido>
    {
        public IRepositorioPedidos Repo { get; set; }

        public CUBuscarPedidoPorId(IRepositorioPedidos repo)
        {
            Repo = repo;
        }

        public Pedido Buscar(int id)
        {
            return Repo.FindById(id);
        }
    }
}