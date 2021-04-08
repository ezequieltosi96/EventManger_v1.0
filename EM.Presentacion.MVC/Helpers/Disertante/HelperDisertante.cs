using System.Threading.Tasks;
using EM.IServicio.Disertante;
using EM.IServicio.Disertante.Dto;
using EM.Presentacion.MVC.Models.Disertante;

namespace EM.Presentacion.MVC.Helpers.Disertante
{
    public class HelperDisertante : IHelperDisertante
    {
        private readonly IDisertanteServicio _disertanteServicio;

        public HelperDisertante(IDisertanteServicio disertanteServicio)
        {
            _disertanteServicio = disertanteServicio;
        }

        public async Task<DisertanteViewModel> ObtenerDisertante(long id)
        {
            var dto = (DisertanteDto)await _disertanteServicio.Obtener(id);

            var model = new DisertanteViewModel()
            {
                Id = dto.Id,
                EstaEliminado = dto.EliminadoStr,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Dni = dto.Dni,
                EmpresaId = dto.EmpresaId
            };

            return model;
        }
    }
}
