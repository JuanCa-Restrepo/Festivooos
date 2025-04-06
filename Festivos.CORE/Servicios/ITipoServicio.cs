using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Festivos.Dominio.Entidades;

namespace Festivos.CORE.Servicios
{
    public interface ITipoServicio
    {
        Task<IEnumerable<Tipo>> ObtenerTodos();//asinconicidad
        Task<Tipo> ObtenerPorId(int id); // obtener por id

        Task<IEnumerable<Tipo>> Buscar(int Tipo, string Dato);
    }
}
