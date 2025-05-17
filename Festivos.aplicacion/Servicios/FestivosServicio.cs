using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Festivos.CORE.Repositorio;
using Festivos.CORE.Servicios;
using Festivos.Dominio.DTOs;
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
        public async Task<string> Validar(DateTime fecha)
        {
            var festivos = await _festivosRepositorio.ObtenerTodos();
            DateTime domingoPascua = await ObtenerIniciodeSemanaSanta(fecha.Year);

            foreach (var festivo in festivos)
            {
                DateTime? fechaFestivo = await CalcularFechaFestivo(festivo, fecha.Year, domingoPascua);
                if (fechaFestivo.HasValue && fechaFestivo.Value.Date == fecha.Date)
                {
                    return $"Es festivo: {festivo.Nombre}";
                }
            }

            return "La fecha ingresada no es un festivo.";
        }

        public async Task<IEnumerable<FestivoDTO>> ObtenerAnio(int anio)
        {
            var festivos = await _festivosRepositorio.ObtenerTodos();
            var fechaFestivos = new List<FestivoDTO>();
            DateTime domingoPascua = await ObtenerIniciodeSemanaSanta(anio);

            foreach (var festivo in festivos)
            {
                DateTime? fechaFestivo = await CalcularFechaFestivo(festivo, anio, domingoPascua);
                if (fechaFestivo.HasValue)
                {
                    fechaFestivos.Add(new FestivoDTO
                    {
                        Nombre = festivo.Nombre,
                        Fecha = fechaFestivo.Value.Date
                    });
                }
            }

            return fechaFestivos;
        }

        private async Task<DateTime?> CalcularFechaFestivo(Festivo festivo, int anio, DateTime domingoPascua)
        {
            try
            {
                switch (festivo.TipoId)
                {
                    case 1: // Fijo
                        return new DateTime(anio, festivo.Mes, festivo.Dia);

                    case 2: // Ley Puente Festivo
                        return await ObtenerSiguienteLunes(new DateTime(anio, festivo.Mes, festivo.Dia));

                    case 3: // Basado en Pascua
                        return await AgregarDias(domingoPascua, festivo.DiasPascua + 7);

                    case 4: // Pascua + Ley Puente
                        var baseFecha = await AgregarDias(domingoPascua, festivo.DiasPascua + 7);
                        return await ObtenerSiguienteLunes(baseFecha);

                    default:
                        return null;
                }
            }
            catch
            {
                return null; // En caso de error de fecha no válida, retorna null
            }
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
