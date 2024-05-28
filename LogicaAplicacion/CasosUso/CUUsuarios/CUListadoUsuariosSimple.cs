using DTOs;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUUsuarios
{
    public class CUListadoUsuariosSimple : ICUListado<DTOUsuarioSimple>
    {
        public IRepositorioUsuarios Repo { get; set; }

        public CUListadoUsuariosSimple(IRepositorioUsuarios repo)
        {
            Repo = repo;
        }

        public List<DTOUsuarioSimple> ObtenerListado()
        {
            List<Usuario> usuarios = Repo.FindAll();
            return MapperUsuarios.ToListaDTOUsuarioSimple(usuarios);
        }
    }
}
