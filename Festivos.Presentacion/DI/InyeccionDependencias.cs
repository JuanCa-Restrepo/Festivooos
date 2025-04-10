using Festivos.aplicacion.Servicios;
using Festivos.CORE.Repositorio;
using Festivos.CORE.Servicios;
using Festivos.Infraestructura.Respositorios;
using Festivos.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;
namespace Festivos.Presentacion.DI
{
    public static class InyeccionDependencias
    {

        public static IServiceCollection AgregarDependecias(this IServiceCollection servicios, IConfiguration configuration)
        {
            // Agregar instancia de DbContext
            servicios.AddDbContext<FestivosContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Festivos"));
            });

            // Agregar repositorios
            servicios.AddTransient<IFestivosRepo, FestivoRepositorio>();
            servicios.AddTransient<ITipoRepo, TipoRepositorio>();

            // Agregar servicios (asegurándote de que IFestivoServicio y FestivosServicio están registrados correctamente)
            servicios.AddTransient<IFestivoServicio, FestivosServicio>();
            servicios.AddTransient<ITipoServicio, TipoFestivoServicio>();

            return servicios;
        }








    }
}
