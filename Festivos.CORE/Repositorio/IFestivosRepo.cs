using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Festivos.Dominio.Entidades;

namespace Festivos.CORE.Repositorio
{
    public interface IFestivosRepo
    {
        Task<IEnumerable<Festivo>> ObtenerTodos();//asinconicidad
        Task<Festivo> ObtenerPorId(int id); // obtener por id

        Task<Festivo> Agregar(Festivo festivo); //agregar datos

        Task<Festivo> Actualizar(Festivo festivo); //actualizar datos

        Task<bool> Eliminar(int id); //eliminar datos 

        Task<IEnumerable<Festivo>> Buscar(int Tipo, string Dato);

       
    }
}
