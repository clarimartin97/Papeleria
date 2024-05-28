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
    public class CUAnularPedido : ICUAnularPedido
    {
        public IRepositorioPedidos Repo { get; set; }

        public CUAnularPedido(IRepositorioPedidos repo)
        {
            Repo = repo;
        }


        public void AnularPedido(List<Linea> lineas, Pedido pedido)
        {
            Repo.AnularPedido(lineas, pedido);
        }
    }
}
