using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Articulo
    {
        public int Id { get; set; }
        [StringLength(200, MinimumLength = 10)]
        public string Nombre { get; set; }
        [NotNull]
        [StringLength(13)]
        public string Codigo { get; set; }
        [MinLength(5)]
        public string Descripcion { get; set; }
        public float PrecioVenta { get; set; }
        public int Stock { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Codigo))
                throw new Exception("El código del artículo no puede estar vacío.");
            if (string.IsNullOrEmpty(Nombre))
                throw new Exception("El nombre del artículo no puede estar vacío.");
            if (string.IsNullOrEmpty(Descripcion))
                throw new Exception("La descripción del artículo no puede estar vacía.");
            if (PrecioVenta < 0)
                throw new Exception("El precio de venta del artículo no puede ser menor que cero.");
            if (Stock < 0)
                throw new Exception("El stock del artículo no puede ser menor que cero.");
        }
    }
}
