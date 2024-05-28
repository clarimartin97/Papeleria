using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Direccion
    {
        public int Id { get; set; }

        public string Calle { get; set; }
        public int Numero { get; set; }
        public string Ciudad { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Calle))
                throw new Exception("La calle no puede estar vacía.");
            if (Numero <= 0)
                throw new Exception("El número de la dirección debe ser mayor que cero.");
            if (string.IsNullOrEmpty(Ciudad))
                throw new Exception("La ciudad no puede estar vacía.");
        }
    }
}
