using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pruebacrud.Models.viewmodels
{
    public class Listtablaviewmodel
    {
        public int Id {get; set; }
        public string Nombre_de_pelicula { get; set; }
        public string Genero { get; set; }
        public System.DateTime Fecha_compra { get; set; }



    }
}