using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EM.Presentacion.MVC.Models.Direccion;

namespace EM.Presentacion.MVC.Helpers.Direccion
{
    public interface IHelperDireccion
    {
        Task<long?> ExisteDireccion(DireccionViewModel model);

        Task<long> NuevaDireccion(DireccionViewModel model);

        Task<DireccionViewModel> ObtenerDireccion(long id);
    }
}
