﻿using System.ComponentModel.DataAnnotations;

namespace APIRotonda.Models
{
    public class Restaurante
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string nit { get; set; }
        public string direccion { get; set; }
        public string ciudad { get; set; }

        // Propiedades de navegación
        public List<Plato> Plato { get; set; }
        
    }
}
