namespace EM.Infrestructura.Repositorio
{
    using EM.Dominio.Repositorio;
    using EM.DominioBase;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class Repositorio<T> : IRepositorio<T> where T : EntidadBase
    {
        protected readonly DataContext _context;

        public Repositorio(DataContext context)
        {
            _context = context;
        }

        public async Task Insertar(T entidad)
        {
            if (entidad == null) throw new Exception("La entidad a insertar no puede ser NULL");

            _context.Entry(entidad).State = EntityState.Added;

            await _context.Set<T>().AddAsync(entidad);

            await _context.SaveChangesAsync();
        }

        public async Task Actualizar(T entidad)
        {
            if (entidad == null) throw new Exception("La entidad a actualizar no puede ser NULL");

            _context.Entry(entidad).State = EntityState.Modified;

            _context.Set<T>().Update(entidad);

            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(long entidadId)
        {
            var entidad = _context.Set<T>()
                .FirstOrDefault(x => x.Id == entidadId);

            if (entidad == null) throw new Exception("La entidad a eliminar no puede ser Null");

            entidad.EstaEliminado = !entidad.EstaEliminado;

            await _context.SaveChangesAsync();
        }

        public async Task<T> ObtenerPorId(long id, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool enabledTraking = true)
        {
            IQueryable<T> consulta = _context.Set<T>();

            if (enabledTraking)
            {
                consulta = consulta.AsNoTracking();
            }

            if (include != null)
            {
                consulta = include(consulta);
            }

            return await consulta.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<T>> ObtenerFiltrado(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool enabledTraking = true)
        {
            IQueryable<T> consulta = _context.Set<T>();

            if (enabledTraking)
            {
                consulta = consulta.AsNoTracking();
            }

            if (include != null)
            {
                consulta = include(consulta);
            }

            if (predicate != null)
            {
                consulta = consulta.Where(predicate);
            }

            return orderBy != null ? await orderBy(consulta).ToListAsync() : await consulta.ToListAsync();
        }

        public async Task<IEnumerable<T>> ObtenerTodo(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool enabledTraking = true)
        {
            IQueryable<T> consulta = _context.Set<T>();

            if (enabledTraking)
            {
                consulta = consulta.AsNoTracking();
            }

            if (include != null)
            {
                consulta = include(consulta);
            }

            return orderBy != null ? await orderBy(consulta).ToListAsync() : await consulta.ToListAsync();
        }
    }
}
