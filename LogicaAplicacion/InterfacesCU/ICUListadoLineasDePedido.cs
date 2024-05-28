using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU
{
    public interface ICUListadoLineasDePedido
    {
        List<Linea> ObtenerListadoLineasDePedido(Pedido pedido);
    }
}
