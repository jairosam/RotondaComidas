﻿using System.ComponentModel.DataAnnotations.Schema;

namespace APIRotonda.DTO.Ingrediente
{
    public class IngredienteCreacionDTO
    {
        public string tipo { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal costoUnitario { get; set; }
    }
}
