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
    public class CUAltaLinea : ICUAlta<Linea>
    {
        public IRepositorioLineas RepoLineas { get; set; }

        public CUAltaLinea(IRepositorioLineas repo)
        {
            RepoLineas = repo;
        }

        public void Alta(Linea value)
        {
            RepoLineas.Add(value);
        }
    }
}
