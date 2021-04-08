using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EM.IServicio.Sala.Dto;
using EM.ServicioBase.Dto;

namespace EM.IServicio.Sala
{
    public interface ISalaServicio : ServicioBase.Servicio.IServicio
    {
        Task<IEnumerable<DtoBase>> ObtenerPorEstablecimiento(long establecimientoId, string cadenaBuscar = "", bool mostrarTodos = true);
    }
}
