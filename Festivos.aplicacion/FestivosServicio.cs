using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Festivos.Dominio.Entidades;

namespace Festivos.aplicacion
{
    public class FestivosServicio : I
    {
        public Task<IEnumerable<Festivo>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
        public Task<Festivo> ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Festivo> Agregar(Festivo festivo)
        {
            throw new NotImplementedException();
        }
        public Task<Festivo> Actualizar(Festivo festivo)
        {
            throw new NotImplementedException();
        }
        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Festivo>> Buscar(int Tipo, string Dato)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Festivo>> Validar(int Dia, int Mes)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Festivo>> ObtenerIniciodeSemanaSanta(int anio)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Festivo>> AgregarDias(int anio)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Festivo>> ObtenerSiguienteLunes(int anio)
        {
            throw new NotImplementedException();
        }
    }
    {

    }
}
