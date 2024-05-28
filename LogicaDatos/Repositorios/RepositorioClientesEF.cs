using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioClientesEF : IRepositorioClientes
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioClientesEF(LibreriaContext ctx)
        {
            Contexto = ctx;
        }

        //Agrega un nuevo cliente.
        public void Add(Cliente nuevo)
        {
            nuevo.Validar();

            Contexto.Clientes.Add(nuevo);
            Contexto.SaveChanges();
        }

        //Devuelve una lista con todos los clientes.
        public List<Cliente> FindAll()
        {
            return Contexto.Clientes.ToList();
        }

        //Devuelve un cliente por su id.
        public Cliente FindById(int id)
        {
            return Contexto.Clientes.Find(id);
        }

        //Elimina un cliente por su id.
        public void Remove(int id)
        {
            Cliente aBorrar = new Cliente() { Id = id };
            Contexto.Clientes.Remove(aBorrar);
            Contexto.SaveChanges();
        }

        //Actualiza un cliente.
        public void Update(Cliente obj)
        {
            obj.Validar();
            Contexto.Update(obj);
            Contexto.SaveChanges();
        }

        //Devuelve un cliente por su RazonSocial y Rut.
        public Cliente BuscarRR(string RazonSocial, string Rut)
        {
            return Contexto.Clientes
                    .Where(c => c.RazonSocial == RazonSocial && c.Rut == Rut)
                    .FirstOrDefault();
        }

        //Devuelve una lista con los clientes que tengan los ids de la lista clientesIds.
        public List<Cliente> FindAllByIds(List<int> clientesIds)
        {
            return Contexto.Clientes
                .Where(c => clientesIds.Contains(c.Id))
                .ToList();
        }

        //Devuelve una lista con los clientes que tengan los ids de la lista de pedidos.
        public List<Cliente> ListadoClientesPedidos(List<Pedido> pedidos)
        {
            return Contexto.Clientes
                .Where(c => pedidos.Select(p => p.ClienteId).Contains(c.Id))
                .ToList();
        }
    }
}
