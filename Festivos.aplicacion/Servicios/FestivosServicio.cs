using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Festivos.CORE.Repositorio;
using Festivos.CORE.Servicios;
using Festivos.Dominio.Entidades;

namespace Festivos.aplicacion.Servicios
{
    public class FestivosServicio : IFestivoServicio
    {
        private readonly IFestivosRepo _festivosRepositorio;

        public FestivosServicio(IFestivosRepo festivosRepo)
        {
            _festivosRepositorio = festivosRepo;
        }

        public async Task<IEnumerable<Festivo>> ObtenerTodos()
        {
            // Aquí va la lógica de negocio para obtener todos los festivales
            return await _festivosRepositorio.ObtenerTodos();
        }

    
        public async Task<Festivo> ObtenerPorId(int id)
        {
            return await _festivosRepositorio.ObtenerPorId(id);
        }
        public async Task<Festivo> Agregar(Festivo festivo)
        {
            return await _festivosRepositorio.Agregar(festivo);
        }
        public async Task<Festivo> Actualizar(Festivo festivo)
        {
            return await _festivosRepositorio.Actualizar(festivo);
        }
        public async Task<bool> Eliminar(int id)
        {
            return await _festivosRepositorio.Eliminar(id);
        }
        public async Task<IEnumerable<Festivo>> Buscar(int opcion, string Dato)
        {
            return await _festivosRepositorio.Buscar(opcion, Dato);
        }
        public async Task<string> Validar(int Dia, int Mes, int anio)
        {
            DateTime fecha;

            // Validar si la fecha es válida
            try
            {
                fecha = new DateTime(anio, Mes, Dia);  // Verifica que la fecha sea válida
                
            }
            catch (ArgumentOutOfRangeException)
            {
                // Si la fecha es inválida, devolvemos un mensaje sin lanzar error
                return "La fecha ingresada no es válida.";
            }

            // Obtener los festivos desde el repositorio
            var festivos = await _festivosRepositorio.ObtenerTodos();
            DateTime DomingoRamos = await ObtenerIniciodeSemanaSanta(fecha.Year);

            // Buscar si la fecha ingresada corresponde a un festivo
            foreach (var festivo in festivos)
            {
                DateTime fechaFestivo;

                switch (festivo.TipoId)
                {
                    case 1: // Fijo
                            // Para un festivo fijo, se crea la fecha con el mismo año y el día/mes correspondiente
                        fechaFestivo = new DateTime(fecha.Year, festivo.Mes, festivo.Dia);
                        break;

                    case 2: // Ley Puente Festivo
                            // Para un festivo de ley puente, ajustamos la fecha al lunes más cercano
                        fechaFestivo = await ObtenerSiguienteLunes(new DateTime(fecha.Year, festivo.Mes, festivo.Dia));
                        break;

                    case 3: // Basado en Pascua
                            // Para un festivo basado en Pascua, calculamos la fecha de Pascua y le sumamos los días correspondientes
                        var DomingoPascua = await ObtenerIniciodeSemanaSanta(fecha.Year);
                        fechaFestivo = await AgregarDias(DomingoPascua, (festivo.DiasPascua + 7));
                        break;

                    case 4: // Pascua + Ley Puente
                            // Para Pascua + Ley Puente, calculamos la Pascua y luego ajustamos la fecha al lunes más cercano
                        var basePascua = await AgregarDias(await ObtenerIniciodeSemanaSanta(fecha.Year), (festivo.DiasPascua + 7));
                        fechaFestivo = await ObtenerSiguienteLunes(basePascua);
                        break;

                    default:
                        continue; // Si no es ninguno de los tipos anteriores, pasamos al siguiente festivo
                }

                // Si la fecha ingresada coincide con el festivo calculado, retornamos el nombre del festivo
                if (fechaFestivo.Date == fecha.Date)
                    return $"Es festivo: {festivo.Nombre}";
            }

            // Si no se encuentra ningún festivo para esa fecha
            return "La fecha ingresada no es un festivo.";
        }
        public async Task<DateTime> ObtenerIniciodeSemanaSanta(int anio)
        {
            
                int a, b, c, d, dias;
                a = anio % 19;
                b = anio % 4;
                c = anio % 7;
                d = (19 * a + 24) % 30;
                dias = d + (2 * b + 4 * c + 6 * d + 5) % 7;

                int dia = 15 + dias;
                int mes = 3;

                if (dia > 31)
                {
                    dia = dia - 31;
                    mes = mes + 1;
                }

                // Crear la fecha del Domingo de Pascua
                DateTime domingoDeRamos = new DateTime(anio, mes, dia);

               return domingoDeRamos;
            }
        public async Task<DateTime> AgregarDias(DateTime fecha, int dias)
        {
            return fecha.AddDays(dias);
        }
        public async Task<DateTime> ObtenerSiguienteLunes(DateTime fecha)
        {
            DayOfWeek diaSemana = fecha.DayOfWeek;
            int diasLunes = ((int)DayOfWeek.Monday - (int)diaSemana + 7) % 7;
            return await AgregarDias(fecha, diasLunes);
        }
    }

}
