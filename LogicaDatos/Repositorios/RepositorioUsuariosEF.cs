using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace LogicaDatos.Repositorios
{
    public class RepositorioUsuariosEF : IRepositorioUsuarios
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioUsuariosEF(LibreriaContext ctx)
        {
            Contexto = ctx;
        }

        //Agrega un nuevo usuario.
        public void Add(Usuario nuevo)
        {
            nuevo.Validar();

            Contexto.Usuarios.Add(nuevo);
            Contexto.SaveChanges();
        }

        //Devuelve una lista con todos los usuarios.
        public List<Usuario> FindAll()
        {
            return Contexto.Usuarios.ToList();
        }

        //Devuelve un usuario por su id.
        public Usuario FindById(int id)
        {
            return Contexto.Usuarios.Find(id);
        }

        //Elimina un usuario por su id.
        public void Remove(int id)
        {
            Usuario aBorrar = new Usuario() { Id = id };
            Contexto.Usuarios.Remove(aBorrar);
            Contexto.SaveChanges();
        }

        //Actualiza un usuario.
        public void Update(Usuario obj)
        {
            obj.Validar();
            Contexto.Update(obj);
            Contexto.SaveChanges();
        }

        //Logea al usuario con el email y contraseña pasados por parámetro.
        public Usuario Login(string email, string password)
        {
            return Contexto.Usuarios
                .AsEnumerable()
                .Where(us => us.Email.Valor == email && us.Contrasenia == password)
                .FirstOrDefault();
        }
    }
}
