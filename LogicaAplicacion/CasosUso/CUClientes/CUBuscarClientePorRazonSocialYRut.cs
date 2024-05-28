using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUClientes
{
    public class CUBuscarClientePorRazonSocialYRut : ICUBuscarClientePorRazonSocialYRut
    {
        public IRepositorioClientes RepoClientes { get; set; }

        public CUBuscarClientePorRazonSocialYRut(IRepositorioClientes repo)
        {
            RepoClientes = repo;
        }

        public Cliente BuscarClientePorRazonSocialYRut(string RazonSocial, string Rut)
        {
            return RepoClientes.BuscarRR(RazonSocial, Rut);
        }
    }
}
