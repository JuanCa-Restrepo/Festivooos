﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Festivos.Dominio.Entidades;
using Festivos.Dominio.DTOs;


namespace Festivos.CORE.Servicios
{
    public interface IFestivoServicio
    {
        Task<IEnumerable<Festivo>> ObtenerTodos();
        Task<Festivo> ObtenerPorId(int id); // obtener por id

        Task<Festivo> Agregar(Festivo festivo); //agregar datos

        Task<Festivo> Actualizar(Festivo festivo); //actualizar datos

        Task<bool> Eliminar(int id); //eliminar datos 

        Task<IEnumerable<Festivo>> Buscar(int opcion, string Dato);

        Task<string> Validar(DateTime fecha);// valida que la fecha ingresada corresponda

        Task<DateTime> ObtenerIniciodeSemanaSanta(int anio); // calcula la fecha del domingo de pascua

        Task<DateTime> AgregarDias(DateTime fecha, int dias);

        Task<DateTime> ObtenerSiguienteLunes(DateTime fecha);

        Task<IEnumerable<FestivoDTO>> ObtenerAnio(int anio);

    }
}
