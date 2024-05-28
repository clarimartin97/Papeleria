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
    public class CUCalcularPrecioPedido : ICUCalcularPrecioPedido
    {
        public IRepositorioPedidos Repo { get; set; }

        public CUCalcularPrecioPedido(IRepositorioPedidos repo)
        {
            Repo = repo;
        }

        public double CalcularPrecioPedido(Pedido pedido)
        {
            return Repo.CalcularPrecio(pedido);
        }
    }
}
