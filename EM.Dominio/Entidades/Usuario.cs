namespace EM.Dominio.Entidades
{
    using System;
    using EM.DominioBase;

    public class Usuario : EntidadBase
    {
        public string Mail { get; set; }

        public string Password { get; set; }

        public DateTime FechaAlta { get; set; }

        public long RolId { get; set; }

        public virtual Rol Rol { get; set; }
    }
}
