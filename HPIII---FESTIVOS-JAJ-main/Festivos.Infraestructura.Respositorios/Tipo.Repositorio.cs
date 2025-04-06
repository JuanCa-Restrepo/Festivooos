using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Festivos.CORE.Repositorio;
using Festivos.Dominio.Entidades;
using Festivos.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;

namespace Festivos.Infraestructura.Respositorios
{
    public class TipoRepositorio : ITipoRepo
    {
        private readonly FestivosContext context;

        public TipoRepositorio(FestivosContext context)
        {
            this.context = context;
        }

        public async Task<Tipo> Agregar(Tipo tipo)
        {
            var tipoagregado = await context.Tipos.AddAsync(tipo);
            await context.SaveChangesAsync();
            return tipoagregado.Entity;
        }

        public async Task<Tipo> Actualizar(Tipo tipo)
        {
            var tipoexistente = await context.Tipos.FindAsync(tipo.Id);
            if (tipoexistente == null) return null;
            context.Entry(tipoexistente).CurrentValues.SetValues(tipo);
            await context.SaveChangesAsync();
            return await context.Tipos.FindAsync(tipo.Id);
        }

        public async Task<IEnumerable<Tipo>> Buscar(string Dato)
        {
            return await context.Tipos
                .Where(item => item.TipoFestivo.Contains(Dato)).ToListAsync();
        }

        public async Task<bool> Eliminar(int id)
        {
            var tipoexistente = await context.Tipos.FindAsync(id);
            if (tipoexistente == null) return false;

            try
            {
                context.Tipos.Remove(tipoexistente);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Tipo> ObtenerPorId(int id)
        {
            return await context.Tipos.FindAsync(id);
        }

        public async Task<IEnumerable<Tipo>> ObtenerTodos()
        {
            return await context.Tipos.ToListAsync();
        }
    }
}
