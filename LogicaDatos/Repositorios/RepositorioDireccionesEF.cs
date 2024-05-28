using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioDireccionesEF : IRepositorioDirecciones
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioDireccionesEF(LibreriaContext ctx)
        {
            Contexto = ctx;
        }

        //Agrega una nueva dirección.
        public void Add(Direccion nuevo)
        {
            nuevo.Validar();

            Contexto.Direcciones.Add(nuevo);
            Contexto.SaveChanges();
        }

        //Devuelve una lista con todas las direcciones.
        public List<Direccion> FindAll()
        {
            return Contexto.Direcciones.ToList();
        }

        //Devuelve una dirección por su id.
        public Direccion FindById(int id)
        {
            return Contexto.Direcciones.Find(id);
        }

        //Elimina una dirección por su id.
        public void Remove(int id)
        {
            Direccion aBorrar = new Direccion() { Id = id };
            Contexto.Direcciones.Remove(aBorrar);
            Contexto.SaveChanges();
        }

        //Actualiza una dirección.
        public void Update(Direccion obj)
        {
            obj.Validar();
            Contexto.Update(obj);
            Contexto.SaveChanges();
        }
    }
}
