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
    public class FestivoRepositorio : IFestivosRepo
    {
     

        private readonly FestivosContext context;

        public FestivoRepositorio(FestivosContext context)
        {
            this.context = context;
        }

        public async Task<Festivo> Agregar(Festivo festivo)
        {
            var festivoagregado = await context.Festivos.AddAsync(festivo);
            await context.SaveChangesAsync();
            return festivoagregado.Entity;
        }
        public async Task<Festivo> Actualizar(Festivo festivo)
        {
            var festivoexistente = await context.Festivos.FindAsync(festivo.Id);
            if (festivoexistente == null) return null;
           
            context.Entry(festivoexistente).CurrentValues.SetValues(festivo);
            await context.SaveChangesAsync();
            return await context.Festivos.FindAsync(festivo.Id);
        }
        public async Task<IEnumerable<Festivo>> Buscar( string Dato)
        {
            return await context.Festivos
                .Where(item => ( item.Nombre.Contains(Dato))).ToListAsync();
                
        }

        public async Task<bool> Eliminar(int id)
        {
            var festivoexistente = await context.Festivos.FindAsync(id);
            if (festivoexistente == null) return false;

            try
            {
                context.Festivos.Remove(festivoexistente);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<Festivo> ObtenerPorId(int id)
        {
            return await context.Festivos.FindAsync(id);
        }
        public async Task<IEnumerable<Festivo>> ObtenerTodos()
        {
            return await context.Festivos.ToArrayAsync();
        }

       
    }
    }

