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
    public class CUAltaPedido : ICUAlta<Pedido>
    {
        public IRepositorioPedidos Repo { get; set; }

        public CUAltaPedido(IRepositorioPedidos repo)
        {
            Repo = repo;
        }

        public void Alta(Pedido value)
        {
            Repo.Add(value);
        }
    }
}
