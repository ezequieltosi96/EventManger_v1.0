namespace EM.Dominio.Repositorio
{
    using EM.DominioBase;
    using Microsoft.EntityFrameworkCore.Query;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IRepositorio<T> where T : EntidadBase
    {
        Task Insertar(T entidad);

        Task Actualizar(T entidad);

        Task Eliminar(long entidadId);

        Task<T> ObtenerPorId(long id,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool enabledTraking = true);

        Task<IEnumerable<T>> ObtenerFiltrado(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool enabledTraking = true);

        Task<IEnumerable<T>> ObtenerTodo(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool enabledTraking = true);
    }
}
