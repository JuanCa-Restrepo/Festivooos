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
    public class TipoFestivoServicio : ITipoServicio
    {
        private readonly ITipoRepo repositorio;

        public TipoFestivoServicio(ITipoRepo repositorio)
        {
            this.repositorio = repositorio;
        }
        public async Task<Tipo> Actualizar(Tipo tipo)
        {
            return await repositorio.Actualizar(tipo);
        }

        public async Task<Tipo> Agregar(Tipo tipo)
        {
            return await repositorio.Agregar(tipo);
        }

        public async Task<IEnumerable<Tipo>> Buscar(int Tipo, string Dato)
        {
            return await repositorio.Buscar(Tipo, Dato);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await repositorio.Eliminar(id);
        }

        public async Task<Tipo> ObtenerPorId(int id)
        {
            return await repositorio.ObtenerPorId(id);
        }

        public async Task<IEnumerable<Tipo>> ObtenerTodos()
        {
            return await repositorio.ObtenerTodos();
        }
    }
}
