using Festivos.CORE.Servicios;
using Festivos.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Festivos.Presentacion.Controllers
{
    [ApiController]
    [Route("api/TipoFestivo")]
    public class TipoFestivosControllers : ControllerBase

    {
        private readonly ITipoServicio Servicio;

        public TipoFestivosControllers(ITipoServicio servicio)
        {
            this.Servicio = servicio;
        }

        [HttpGet("ObtenerTodos")]
        public async Task<IEnumerable<Tipo>> ObtenerTodos()
        {
            return await Servicio.ObtenerTodos();
        }

        [HttpGet("ObtenerPorId/{id}")]
        public async Task<Tipo> ObtenerPorId(int id)
        {
            return await Servicio.ObtenerPorId(id);
        }

        [HttpPost("Agregar")]
        public async Task<Tipo> Agregar([FromBody] Tipo tipo)
        {
            return await Servicio.Agregar(tipo);
        }

        [HttpPut("Actualizar")]
        public async Task<Tipo> Actualizar([FromBody] Tipo tipo)
        {
            return await Servicio.Actualizar(tipo);
        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<bool> Eliminar(int id)
        {
            return await Servicio.Eliminar(id);
        }

        [HttpGet("Buscar/{Tipo}/{Dato}")]
        public async Task<IEnumerable<Tipo>> Buscar(int Tipo, string Dato)
        {
            return await Servicio.Buscar(Tipo, Dato);
        }








    }
}
