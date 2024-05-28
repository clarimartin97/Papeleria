using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioClientes : IRepositorio<Cliente>
    {
        public Cliente BuscarRR(string RazonSocial, string Rut);
        public List<Cliente> FindAllByIds(List<int> clientesIds);
        public List<Cliente> ListadoClientesPedidos(List<Pedido> pedidos);
    }
}
