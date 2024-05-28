using LogicaNegocio.Dominio;
using LogicaNegocio.VOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MapperUsuarios
    {
        public static Usuario ToUsuario(DTOAltaUsuario dto)
        {
            return new Usuario()
            {
                Email = new EmailUsuario(dto.Email),
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Contrasenia = dto.Contrasenia,
                ContraseniaEncriptada = dto.ContraseniaEncriptada,
            };
        }

        public static DTOUsuarioSimple ToDTOUsuarioSimple(Usuario usuario)
        {
            return new DTOUsuarioSimple()
            {
                Id = usuario.Id,
                Email = usuario.Email.Valor,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
            };
        }

        public static List<DTOUsuarioSimple> ToListaDTOUsuarioSimple(List<Usuario> usuarios)
        {
            return usuarios.Select(u => ToDTOUsuarioSimple(u)).ToList();
        }
    }
}
