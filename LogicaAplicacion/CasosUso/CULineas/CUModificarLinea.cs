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
    public class CUModificarLinea : ICUModificar<Linea>
    {
        public IRepositorioLineas RepoLineas { get; set; }

        public CUModificarLinea(IRepositorioLineas repo)
        {
            RepoLineas = repo;
        }

        public void Modificar(Linea t)
        {
            RepoLineas.Update(t);
        }
    }
}
