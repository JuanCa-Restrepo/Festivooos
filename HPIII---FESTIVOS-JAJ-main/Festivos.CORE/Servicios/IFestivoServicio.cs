using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Festivos.Dominio.Entidades;


namespace Festivos.CORE.Servicios
{
    public interface IFestivoServicio
    {
        Task<IEnumerable<Festivo>> ObtenerTodos();//asinconicidad
        Task<Festivo> ObtenerPorId(int id); // obtener por id

        Task<Festivo> Agregar(Festivo festivo); //agregar datos

        Task<Festivo> Actualizar(Festivo festivo); //actualizar datos

        Task<bool> Eliminar(int id); //eliminar datos 

        Task<IEnumerable<Festivo>> Buscar(int Tipo, string Dato);

        Task<IEnumerable<Festivo>> Validar(int Dia, int Mes);// valida que la fecha ingresada corresponda

        Task<IEnumerable<Festivo>> CalcularPascua(int anio); // calcula la fecha del domingo de pascua
    }
}
