using EM.Presentacion.MVC.Models.Sala;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Helpers.Sala
{
    public interface IHelperSala
    {
        Task<SalaViewModel> ObtenerSala(long id);

        Task<bool> ExisteSalaDisponible(long establecimientoId, DateTime fecha, long? eventoId = null);

        Task<IEnumerable<SelectListItem>> PoblarComboPorEstablecimiento(long establecimientoId, DateTime? fecha = null);
    }
}
