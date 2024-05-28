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
    public class CUListadoClientesPorIds : ICUListadoClientesPorIds
    {
        public IRepositorioClientes Repo { get; set; }

        public CUListadoClientesPorIds(IRepositorioClientes repo)
        {
            Repo = repo;
        }

        public List<Cliente> ObtenerListadoClientesPorIds(List<int> clientesIds)
        {
            return Repo.FindAllByIds(clientesIds);
        }
    }
}
