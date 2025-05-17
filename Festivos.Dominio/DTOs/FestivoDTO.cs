using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Festivos.Dominio.DTOs
{
    public class FestivoDTO
    {
        [JsonIgnore] // Oculta esta propiedad en el JSON resultante
        public DateTime Fecha { get; set; }

        [JsonPropertyName("fecha")] // Esta será la propiedad visible en el JSON
        public string FechaFormateada => Fecha.ToString("dd-MM-yyyy");

        public string Nombre { get; set; }
    }
}
