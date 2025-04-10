using Festivos.CORE.Repositorio;
using Festivos.CORE.Servicios;
using Festivos.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<Festivo> Agregar([FromBody] Festivo festivo)
        {
            return await servicio.Agregar(festivo);
        }

        [HttpPut("Actualizar")]
        public async Task<Festivo> Actualizar([FromBody] Festivo festivo)
        {
            return await servicio.Actualizar(festivo);
        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<bool> Eliminar(int id)
        {
            return await servicio.Eliminar(id);
        }

        [HttpGet("Buscar/{Dato}")]
        public async Task<IEnumerable<Festivo>> Buscar( string Dato)
        {
            return await servicio.Buscar( Dato);
        }

        [HttpGet("Validar/{Dia}/{Mes}/{anio}")]
        public async Task<string> Validar(int Dia, int Mes, int anio)
        {
            return await servicio.Validar(Dia, Mes, anio);
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
