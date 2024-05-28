using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioLineas : IRepositorio<Linea>
    {
        public List<Linea> ObtenerListadoLineasDePedido(Pedido pedido);
    }
}
