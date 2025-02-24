﻿using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioArticulos : IRepositorio<Articulo>
    {
        public List<Articulo> OrdenarAsc(List<Articulo> articulos);
        public List<Articulo> ListadoArticulosDeLineas(List<Linea> lineas);
    }
}
