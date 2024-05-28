using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Cliente
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        [StringLength(12)]
        public string Rut { get; set; }
        public Direccion Direccion { get; set; }
        public float DistanciaKm { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(RazonSocial))
                throw new Exception("La razón social no puede estar vacía.");
            if (string.IsNullOrEmpty(Rut))
                throw new Exception("El Rut no puede estar vacío.");
            if (Direccion == null)
                throw new Exception("La dirección no puede ser nula.");
            if (DistanciaKm < 0)
                throw new Exception("La distancia en kilómetros no puede ser negativa.");
        }
    }
}
