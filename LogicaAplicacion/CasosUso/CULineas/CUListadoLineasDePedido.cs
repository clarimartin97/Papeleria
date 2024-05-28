using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CULineas
{
    public class CUListadoLineasDePedido : ICUListadoLineasDePedido
    {
        public IRepositorioLineas Repo { get; set; }

        public CUListadoLineasDePedido(IRepositorioLineas repo)
        {
            Repo = repo;
        }

        public List<Linea> ObtenerListadoLineasDePedido(Pedido pedido)
        {
            return Repo.ObtenerListadoLineasDePedido(pedido);
        }
    }
}
