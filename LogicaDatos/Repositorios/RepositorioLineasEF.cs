using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioLineasEF : IRepositorioLineas
    {

        public LibreriaContext Contexto { get; set; }

        public RepositorioLineasEF(LibreriaContext ctx)
        {
            Contexto = ctx;
        }

        //Agrega una nueva línea.
        public void Add(Linea nuevo)
        {
            nuevo.Validar();

            Contexto.Lineas.Add(nuevo);
            Contexto.SaveChanges();
        }

        //Devuelve una lista con todas las líneas.
        public List<Linea> FindAll()
        {
            return Contexto.Lineas.ToList();
        }

        //Devuelve una línea por su id.
        public Linea FindById(int id)
        {
            return Contexto.Lineas.Find(id);
        }

        //Elimina una línea por su id.
        public void Remove(int id)
        {
            Linea? aBorrar = Contexto.Lineas.Find(id) ?? throw new Exception("No se encontró la línea");
            Contexto.Lineas.Remove(aBorrar);
            Contexto.SaveChanges();
        }

        //Actualiza una línea.
        public void Update(Linea obj)
        {
            obj.Validar();
            Contexto.Update(obj);
            Contexto.SaveChanges();
        }

        //Devuelve una lista de líneas ordenada que pertenecen a un pedido.
        public List<Linea> ObtenerListadoLineasDePedido(Pedido pedido)
        {
            return Contexto.Lineas
            .Where(l => Contexto.Pedidos
                .Where(p => p.Lineas
                    .Any(lp => lp.Id == l.Id)
                )
                .Select(p => p.Id)
                .FirstOrDefault() == pedido.Id
            )
            .ToList();
        }
    }
}
