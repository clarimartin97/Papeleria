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
    public class CUListadoArticulos : ICUListado<Articulo>
    {
        public IRepositorioArticulos Repo { get; set; }

        public CUListadoArticulos(IRepositorioArticulos repo)
        {
            Repo = repo;
        }

        public List<Articulo> ObtenerListado()
        {
            return Repo.FindAll();
        }
    }
}
