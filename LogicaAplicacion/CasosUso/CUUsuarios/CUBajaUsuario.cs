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
    public class CUBajaUsuario : ICUBaja<Usuario>
    {
        public IRepositorioUsuarios RepoUsuarios { get; set; }

        public CUBajaUsuario(IRepositorioUsuarios repo)
        {
            RepoUsuarios = repo;
        }

        public void Baja(int id)
        {
            RepoUsuarios.Remove(id);
        }
    }
}
