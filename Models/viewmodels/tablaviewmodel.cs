using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pruebacrud.Models.viewmodels
{
    public class tablaviewmodel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display (Name ="Nombre de pelicula")]
        public string Nombre_de_pelicula { get; set; }
        [Required]
        [StringLength(50)]
        [Display (Name = "genero")]
        public string Genero { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "fecha de compra")]
        [DisplayFormat (DataFormatString ="(0:dd-MM-yyyy)",ApplyFormatInEditMode =true)]
        public DateTime Fecha_compra { get; set; }  
    }
}