using System;
using System.Collections.Generic;
using System.Text;
using EM.ServicioBase.Dto;

namespace EM.IServicio.Direccion.Dto
{
    public class DireccionDto : DtoBase
    {
        public string Descripcion { get; set; }

        public long LoclidadId { get; set; }
    }
}
