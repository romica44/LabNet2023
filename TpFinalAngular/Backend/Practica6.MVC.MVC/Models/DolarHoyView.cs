using System;

namespace Practica7.WebApi.Models
{
    public class DolarHoyView
    {
            public decimal? Compra { get; set; }
            public decimal? Venta { get; set; }
            public string Casa { get; set; }
            public string Nombre { get; set; }
            public string FechaActualizacion { get; set; }
        
    }
}