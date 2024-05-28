using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUClientes
{
    public class CUBuscarClientePorId : ICUBuscarPorId<Cliente>
    {
        public IRepositorioClientes RepoClientes { get; set; }

        public CUBuscarClientePorId(IRepositorioClientes repo)
        {
            RepoClientes = repo;
        }

        public Cliente Buscar(int id)
        {
            return RepoClientes.FindById(id);
        }
    }
}
