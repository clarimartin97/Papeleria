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
    public class CUModificarPedido : ICUModificar<Pedido>
    {
        public IRepositorioPedidos RepoPedidos { get; set; }

        public CUModificarPedido(IRepositorioPedidos repo)
        {
            RepoPedidos = repo;
        }

        public void Modificar(Pedido t)
        {
            RepoPedidos.Update(t);
        }
    }
}
