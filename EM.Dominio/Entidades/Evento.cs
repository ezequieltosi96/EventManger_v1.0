namespace EM.Dominio.Entidades
{
    using EM.DominioBase;
    using System;
    using System.Collections.Generic;

    public class Evento : EntidadBase
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int Cupo { get; set; }

        public int CupoDisponible { get; set; }

        public DateTime Fecha { get; set; }

        public long EstablecimientoId { get; set; }

        public long EmpresaId { get; set; }

        public virtual ICollection<Actividad> Actividades { get; set; }

        public virtual Establecimiento Establecimiento { get; set; }

        public virtual Empresa Empresa { get; set; }
    }
}
