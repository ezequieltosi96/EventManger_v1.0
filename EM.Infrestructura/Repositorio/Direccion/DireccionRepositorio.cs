using System;
using System.Collections.Generic;
using System.Text;
using EM.Dominio.Repositorio.Direccion;

namespace EM.Infrestructura.Repositorio.Direccion
{
    public class DireccionRepositorio : Repositorio<Dominio.Entidades.Direccion>, IDireccionRepositorio
    {
        public DireccionRepositorio(DataContext context) : base(context)
        {
        }
    }
}
