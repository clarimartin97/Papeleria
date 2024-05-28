using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DTOUsuarioSimple
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "El email debe tener @dominio.com")]
        public string Email { get; set; }
        [RegularExpression(@"^[a-zA-ZñÑ\s'-]*$", ErrorMessage = "El nombre no puede contener números")]
        public string Nombre { get; set; }
        [RegularExpression(@"^[a-zA-ZñÑ\s'-]*$", ErrorMessage = "El apellido no puede contener números")]
        public string Apellido { get; set; }
    }
}
