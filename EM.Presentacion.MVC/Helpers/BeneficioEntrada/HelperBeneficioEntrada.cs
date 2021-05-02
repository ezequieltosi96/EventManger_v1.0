using EM.IServicio.BeneficioEntrada;
using EM.IServicio.BeneficioEntrada.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Helpers.BeneficioEntrada
{
    public class HelperBeneficioEntrada : IHelperBeneficioEntrada
    {
        private readonly IBeneficioEntradaServicio _beneficioEntradaServicio;

        public HelperBeneficioEntrada(IBeneficioEntradaServicio beneficioEntradaServicio)
        {
            _beneficioEntradaServicio = beneficioEntradaServicio;
        }

        public async Task<IEnumerable<SelectListItem>> PoblarSelect()
        {
            var beneficioEntradas = (IEnumerable<BeneficioEntradaDto>)await _beneficioEntradaServicio.Obtener(String.Empty, false);

            return new SelectList(beneficioEntradas, "Id", "Nombre");
        }

        public async Task<string> ObtenerNombreBeneficioEntrada(long id)
        {
            return ((BeneficioEntradaDto)await _beneficioEntradaServicio.Obtener(id)).Nombre;
        }
    }
}
