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
    public class CUListadoArticulosDeLineas : ICUListadoArticulosDeLineas
    {
        public IRepositorioArticulos RepoArticulos { get; set; }

        public CUListadoArticulosDeLineas(IRepositorioArticulos repo)
        {
            RepoArticulos = repo;
        }

        public List<Articulo> ListadoArticulosDeLineas(List<Linea> lineas)
        {
            return RepoArticulos.ListadoArticulosDeLineas(lineas);
        }
    }
}
