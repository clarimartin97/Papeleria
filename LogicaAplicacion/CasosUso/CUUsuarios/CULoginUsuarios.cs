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
    public class CULoginUsuarios : ICULoginUsuarios
    {
        public IRepositorioUsuarios RepoUsuarios { get; set; }

        public CULoginUsuarios(IRepositorioUsuarios repo)
        {
            RepoUsuarios = repo;
        }

        public Usuario Login(string email, string password)
        {
            return RepoUsuarios.Login(email, password);
        }
    }
}
