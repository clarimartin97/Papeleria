using LogicaNegocio.ExcepcionesPropias;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio.VOs
{
    [Owned]
    public class EmailUsuario
    {
        public string Valor { get; init; }

        public EmailUsuario(string email)
        {
            Valor = email;
            Validar();
        }

        private EmailUsuario() { }

        private void Validar()
        {
            // Validar que el email sea válido con una expresión regular que comprueba que el email tiene un formato correcto.
            if (string.IsNullOrEmpty(Valor) || !Regex.IsMatch(Valor, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$"))
            {
                throw new DatosInvalidosException("El email del usuario no es válido");
            }
        }

        public override bool Equals(object? obj)
        {
            EmailUsuario? otro = obj as EmailUsuario;

            if (otro == null) return false;

            return otro.Valor == Valor;
        }
    }
}
