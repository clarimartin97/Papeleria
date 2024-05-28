using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioArticulosEF : IRepositorioArticulos
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioArticulosEF(LibreriaContext ctx)
        {
            Contexto = ctx;
        }

        //Agrega un nuevo artículo.
        public void Add(Articulo nuevo)
        {
            nuevo.Validar();

            Contexto.Articulos.Add(nuevo);
            Contexto.SaveChanges();
        }

        //Devuelve un artículo por su id.
        public Articulo FindById(int id)
        {
            return Contexto.Articulos.Find(id);
        }

        //Elimina un artículo por su id.
        public void Remove(int id)
        {
            Articulo aBorrar = new Articulo() { Id = id };
            Contexto.Articulos.Remove(aBorrar);
            Contexto.SaveChanges();
        }

        //Devuelve una lista con todos los artículos.
        public List<Articulo> FindAll()
        {
            return Contexto.Articulos.ToList();
        }

        //Actualiza un artículo.
        public void Update(Articulo obj)
        {
            obj.Validar();
            Contexto.Update(obj);
            Contexto.SaveChanges();
        }

        //Devuelve una lista de artículos ordenada por nombre de forma ascendente.
        public List<Articulo> OrdenarAsc(List<Articulo> articulos)
        {
            return articulos
                .OrderBy(a => a.Nombre)
                .ToList();
        }

        //Devuelve la lista de artículos que pertenecen a un pedido (lista de líneas).
        public List<Articulo> ListadoArticulosDeLineas(List<Linea> lineas)
        {
            return Contexto.Articulos
                .Where(a => lineas.Select(l => l.ArticuloId).Contains(a.Id))
                .ToList();
        }
    }
}
