using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Pedido
    {
        public int Id { get; set; }
        public bool Tipo { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int ClienteId { get; set; }
        public List<Linea> Lineas { get; set; }
        public double Recargo { get; set; }
        public float Iva { get; set; }
        public bool Anulado { get; set; }


        public void Validar()
        {
            if (Recargo < 0)
                throw new Exception("El recargo no puede ser negativo");
            if (Iva < 0)
                throw new Exception("El IVA no puede ser negativo");
            if (FechaEntrega == DateTime.MinValue)
                throw new Exception("La fecha de entrega no puede ser nula");
            if (FechaEntrega.Date < FechaPedido.Date)
                throw new Exception("La fecha de entrega no puede ser anterior a la fecha de pedido");
            if (ClienteId <= 0)
                throw new Exception("El cliente no puede ser nulo");
        }
    }
}
