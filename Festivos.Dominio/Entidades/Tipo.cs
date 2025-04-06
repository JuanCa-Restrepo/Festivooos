using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivos.Dominio.Entidades
{
    [Table("Tipo")]
    public class Tipo
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("TipoFestivo")] 
        public required string TipoFestivo { get; set; }
    }
}
