﻿using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUUsuarios
{
    public class CUBuscarUsuarioPorId : ICUBuscarPorId<Usuario>
    {
        public IRepositorioUsuarios RepoUsuarios { get; set; }

        public CUBuscarUsuarioPorId(IRepositorioUsuarios repo)
        {
            RepoUsuarios = repo;
        }

        public Usuario Buscar(int id)
        {
            return RepoUsuarios.FindById(id);
        }
    }
}
