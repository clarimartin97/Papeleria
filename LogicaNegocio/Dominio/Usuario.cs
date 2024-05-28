using LogicaNegocio.VOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "El email debe tener @dominio.com")]
        public EmailUsuario Email { get; set; }
        [RegularExpression(@"^[a-zA-ZñÑ\s'-]*$", ErrorMessage = "El nombre no puede contener números")]
        public string Nombre { get; set; }
        [RegularExpression(@"^[a-zA-ZñÑ\s'-]*$", ErrorMessage = "El apellido no puede contener números")]
        public string Apellido { get; set; }
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[.,;¡!@#])[A-Za-z\d.,;¡!@#]{6,}$", ErrorMessage = "La contraseña debe tener al menos 6 caracteres, una mayúscula, una minúscula, un número y un caracter especial.")]
        [Required(ErrorMessage = "La contraseña es requerida.")]
        public string Contrasenia { get; set; }
        public string ContraseniaEncriptada { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
                throw new Exception("El nombre no puede estar vacío.");
            if (string.IsNullOrEmpty(Apellido))
                throw new Exception("El apellido no puede estar vacío.");
            if (string.IsNullOrEmpty(Contrasenia))
                throw new Exception("La contraseña no puede estar vacía.");
            if (string.IsNullOrEmpty(ContraseniaEncriptada))
                throw new Exception("La contraseña encriptada no puede estar vacía.");
        }
    }
}
