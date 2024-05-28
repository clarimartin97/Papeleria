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
    public class CUListadoArticulosOrdenado : ICUListadoArticulosOrdenado
    {
        public IRepositorioArticulos RepoArticulos { get; set; }

        public CUListadoArticulosOrdenado(IRepositorioArticulos repo)
        {
            RepoArticulos = repo;
        }

        public List<Articulo> OrdenarAlfabeticamenteAsc(List<Articulo> articulos)
        {
            return RepoArticulos.OrdenarAsc(articulos);
        }
    }
}
