using Festivos.CORE.Repositorio;
using Festivos.CORE.Servicios;
using Festivos.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Festivos.Dominio.DTOs;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Festivos.Presentacion.Controllers
{
    [ApiController]
    [Route("api/festivos")]
    public class FestivosControllers : ControllerBase
    {
        private readonly IFestivoServicio servicio;

        public FestivosControllers(IFestivoServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpGet("ObtenerTodos")]
        public async Task<IEnumerable<Festivo>> ObtenerTodos()
        {
            return await servicio.ObtenerTodos();
        }

        [HttpGet("ObtenerPorId/{id}")]
        public async Task<Festivo> ObtenerPorId(int id)
        {
            return await servicio.ObtenerPorId(id);
        }

        [HttpPost("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] FestivosAgregarDTO dto)

        {
            if ((dto.TipoId == 3 || dto.TipoId == 4) && (dto.Dia != 0 || dto.Mes != 0))
            {
                return BadRequest("Para los tipos 3 o 4, el día y el mes deben ser igual a 0");
            }

            if (dto.TipoId == 0 )
            {
                return BadRequest("El tipo no puede ser 0");
            }
            var festivo = new Festivo
            {
                Nombre = dto.Nombre,
                Dia = dto.Dia,
                Mes = dto.Mes,
                DiasPascua = dto.DiasPascua,
                TipoId = dto.TipoId,
                Tipo = null // 👈 Esto evita que EF Core intente insertar el objeto Tipo
            };

            var agregado = await servicio.Agregar(festivo);
            return Ok(agregado);
        }

        [HttpPut("Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody]  FestivoAtualizarDTO dto)
        {
            if ((dto.TipoId == 3 || dto.TipoId == 4) && (dto.Dia != 0 || dto.Mes != 0))
            {
                return BadRequest("Para los tipos 3 o 4, el día y el mes deben ser igual a 0");
            }

            if (dto.TipoId == 0)
            {
                return BadRequest("El tipo no puede ser 0");
            }
            var festivo = new Festivo
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Dia = dto.Dia,
                Mes = dto.Mes,
                DiasPascua = dto.DiasPascua,
                TipoId = dto.TipoId,
                Tipo = null // 👈 Esto evita que EF Core intente insertar el objeto Tipo
            };

            var actualizado = await servicio.Actualizar(festivo);
            return Ok(actualizado);
        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<bool> Eliminar(int id)
        {
            return await servicio.Eliminar(id);
        }

        [HttpGet("Buscar/{opcion}/{Dato}")]
        public async Task<IEnumerable<Festivo>> Buscar(int opcion, string Dato)
        {
            return await servicio.Buscar(opcion, Dato);
        }

       
        [HttpGet("Validar/{fecha}")]
        public async Task<IActionResult> Validar(string fecha)
        {
            // Paso 1: Validar el formato dd-MM-yyyy estrictamente (con regex)
            var regex = new Regex(@"^\d{2}-\d{2}-\d{4}$");

            if (!regex.IsMatch(fecha))
            {
                return BadRequest("El formato es incorrecto. Usa dd-MM-yyyy.");
            }

            // Paso 2: Validar si la fecha es real
            if (!DateTime.TryParseExact(
                    fecha,
                    "dd-MM-yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime fechaParseada))
            {
                return BadRequest("La fecha no existe. Revisa día y mes.");
            }

            var resultado = await servicio.Validar(fechaParseada);
            return Ok(resultado);
        }

        [HttpGet("listar/{anio}")]
        public async Task<IEnumerable<FestivoDTO>> ObtenerAnio(int anio)
        {
            return await servicio.ObtenerAnio(anio);
        }



        [HttpGet("ObtenerIniciodeSemanaSanta/{anio}")]
        public async Task<DateTime> ObtenerIniciodeSemanaSanta(int anio)
        {
            return await servicio.ObtenerIniciodeSemanaSanta(anio);
        }

        [HttpGet("AgregarDias/{fecha}/{dias}")]
        public async Task<DateTime> AgregarDias(DateTime fecha, int dias)
        {
            return await servicio.AgregarDias(fecha, dias);
        }

        [HttpGet("ObtenerSiguienteLunes/{fecha}")]
        public async Task<DateTime> ObtenerSiguienteLunes(DateTime fecha)
        {
            return await servicio.ObtenerSiguienteLunes(fecha);

        }


    }
}
