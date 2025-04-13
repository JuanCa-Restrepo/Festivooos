using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivos.Dominio.DTOs
{
    public class FestivosAgregarDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int DiasPascua { get; set; }
        public int TipoId { get; set; }
    }

    
}
