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
    public class CUAltaUsuario : ICUAlta<DTOAltaUsuario>
    {
        public IRepositorioUsuarios RepoUsuarios { get; set; }

        public CUAltaUsuario(IRepositorioUsuarios repo)
        {
            RepoUsuarios = repo;
        }

        public void Alta(DTOAltaUsuario value)
        {
            Usuario u = MapperUsuarios.ToUsuario(value);
            RepoUsuarios.Add(u);
        }
    }
}
