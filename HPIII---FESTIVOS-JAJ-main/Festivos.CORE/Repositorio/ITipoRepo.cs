using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Festivos.Dominio.Entidades;

namespace Festivos.CORE.Repositorio
{
    public interface ITipoRepo
    {
        Task<IEnumerable<Tipo>> ObtenerTodos();//asinconicidad
        Task<Tipo> ObtenerPorId(int id); // obtener por id

        Task<Tipo> Agregar(Tipo tipo); //agregar datos

        Task<Tipo> Actualizar(Tipo tipo); //actualizar datos

        Task<bool> Eliminar(int id); //eliminar datos 

        Task<IEnumerable<Tipo>> Buscar( string Dato);
    }
}
