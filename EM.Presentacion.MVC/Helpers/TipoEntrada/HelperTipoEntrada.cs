using EM.IServicio.TipoEntrada;
using EM.IServicio.TipoEntrada.Dto;
using EM.Presentacion.MVC.Helpers.BeneficioEntrada;
using EM.Presentacion.MVC.Models.TipoEntrada;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Helpers.TipoEntrada
{
    public class HelperTipoEntrada : IHelperTipoEntrada
    {
        private readonly ITipoEntradaServicio _tipoEntradaServicio;
        private readonly IHelperBeneficioEntrada _helperBeneficioEntrada;

        public HelperTipoEntrada(ITipoEntradaServicio tipoEntradaServicio, IHelperBeneficioEntrada helperBeneficioEntrada)
        {
            _tipoEntradaServicio = tipoEntradaServicio;
            _helperBeneficioEntrada = helperBeneficioEntrada;
        }

        public async Task<IEnumerable<SelectListItem>> PoblarSelect(long empresaId)
        {
            var tipos = (IEnumerable<TipoEntradaDto>)await _tipoEntradaServicio.ObtenerPorEmpresa(empresaId, String.Empty, false);

            return new SelectList(tipos, "Id", "Nombre");
        }

        public async Task<TipoEntradaViewModel> Obtener(long tipoEntradaId)
        {
            var tipoEntrada = (TipoEntradaDto)await _tipoEntradaServicio.Obtener(tipoEntradaId);

            var model = new TipoEntradaViewModel()
            {
                Id = tipoEntrada.Id,
                BeneficioEntradaId = tipoEntrada.BeneficioEntradaId,
                BeneficioEntradaNombre = await _helperBeneficioEntrada.ObtenerNombreBeneficioEntrada(tipoEntrada.BeneficioEntradaId),
                Nombre = tipoEntrada.Nombre,
                EstaEliminado = tipoEntrada.EliminadoStr
            };

            return model;
        }
    }
}
