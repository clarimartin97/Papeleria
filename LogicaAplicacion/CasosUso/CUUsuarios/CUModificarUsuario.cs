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
    public class CUModificarUsuario : ICUModificar<Usuario>
    {
        public IRepositorioUsuarios RepoUsuarios { get; set; }

        public CUModificarUsuario(IRepositorioUsuarios repo)
        {
            RepoUsuarios = repo;
        }

        public void Modificar(Usuario u)
        {
            RepoUsuarios.Update(u);
        }
    }
}
