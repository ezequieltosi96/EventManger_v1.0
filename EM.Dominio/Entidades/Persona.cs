﻿namespace EM.Dominio.Entidades
{
    using EM.DominioBase;

    public class Persona : EntidadBase
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Dni { get; set; }
    }
}
