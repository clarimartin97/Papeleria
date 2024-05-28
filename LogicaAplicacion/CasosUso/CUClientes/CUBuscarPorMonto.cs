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
    public class CUBuscarPorMonto : ICUBuscarPorMonto
    {
        public IRepositorioPedidos Repo { get; set; }

        public CUBuscarPorMonto(IRepositorioPedidos repo)
        {
            Repo = repo;
        }

        public List<int> BuscarPorMonto(double monto)
        {
            return Repo.BuscarPorMonto(monto);
        }
    }
}
