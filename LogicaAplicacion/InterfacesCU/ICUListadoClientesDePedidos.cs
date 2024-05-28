using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU
{
    public interface ICUListadoClientesDePedidos
    {
        public List<Cliente> ListadoClientesDePedidos(List<Pedido> pedidos);
    }
}
