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
    public class CUListadoClientes : ICUListado<Cliente>
    {
        public IRepositorioClientes Repo { get; set; }

        public CUListadoClientes(IRepositorioClientes repo)
        {
            Repo = repo;
        }

        public List<Cliente> ObtenerListado()
        {
            return Repo.FindAll();
        }
    }
}
