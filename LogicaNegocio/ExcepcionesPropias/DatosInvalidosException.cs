using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ExcepcionesPropias
{
    public class DatosInvalidosException : Exception
    {
        public DatosInvalidosException() : base()
        {
            throw new Exception("Datos inválidos");
        }

        public DatosInvalidosException(string message) : base(message)
        {
            throw new Exception(message);
        }

        public DatosInvalidosException(string mensaje, Exception inner) : base(mensaje, inner)
        {
            throw new Exception(mensaje, inner);
        }
    }
}
