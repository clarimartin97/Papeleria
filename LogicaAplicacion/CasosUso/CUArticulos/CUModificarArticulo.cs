using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUArticulos
{
    public class CUModificarArticulo : ICUModificar<Articulo>
    {
        public IRepositorioArticulos RepoArticulos { get; set; }

        public CUModificarArticulo(IRepositorioArticulos repo)
        {
            RepoArticulos = repo;
        }

        public void Modificar(Articulo t)
        {
            RepoArticulos.Update(t);
        }
    }
}
