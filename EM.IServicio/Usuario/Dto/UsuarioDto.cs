namespace EM.IServicio.Usuario.Dto
{
    using System;
    using EM.ServicioBase.Dto;

    public class UsuarioDto : DtoBase
    {
        public string Mail { get; set; }

        public string Password { get; set; }

        public DateTime FechaAlta { get; set; }

        public long RolId { get; set; }
    }
}
