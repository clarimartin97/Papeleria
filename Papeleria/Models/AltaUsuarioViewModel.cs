using LogicaNegocio.VOs;
using System.ComponentModel.DataAnnotations;

namespace Papeleria.Models
{
    public class AltaUsuarioViewModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "El email debe tener @dominio.com")]
        public string Email { get; set; }
        [RegularExpression(@"^[a-zA-ZñÑ\s'-]*$", ErrorMessage = "El nombre no puede contener números")]
        public string Nombre { get; set; }
        [RegularExpression(@"^[a-zA-ZñÑ\s'-]*$", ErrorMessage = "El apellido no puede contener números")]
        public string Apellido { get; set; }
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[.,;¡!@#])[A-Za-z\d.,;¡!@#]{6,}$", ErrorMessage = "La contraseña debe tener al menos 6 caracteres, una mayúscula, una minúscula, un número y un caracter especial")]
        [Required(ErrorMessage = "La contraseña es requerida.")]
        public string Contrasenia { get; set; }
    }
}
