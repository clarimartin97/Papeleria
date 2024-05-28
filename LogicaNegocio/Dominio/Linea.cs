using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Linea
    {
        public int Id { get; set; }
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public bool Anulado { get; set; }

        public void Validar()
        {
            if (Cantidad <= 0)
                throw new Exception("La cantidad debe ser mayor a cero.");
            if (PrecioUnitario <= 0)
                throw new Exception("El precio unitario debe ser mayor a cero.");
        }
    }
}
