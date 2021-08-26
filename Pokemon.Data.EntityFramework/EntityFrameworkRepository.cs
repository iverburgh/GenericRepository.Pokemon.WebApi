using Microsoft.EntityFrameworkCore;
using Pokemon.Data.EntityFramework;
using Pokemon.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pokemon.Data.EntityFramework
{
    internal class EntityFrameworkRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly IPokemonDbContext _pokemonDbContext;

        public EntityFrameworkRepository(IPokemonDbContext pokemonDbContext)
        {
            _pokemonDbContext = pokemonDbContext;
        }

        public virtual async Task<T> SaveOrUpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(SaveOrUpdateAsync)} entity must not be null");
            }
            try
            {
                _pokemonDbContext.Update(entity);
                await _pokemonDbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            try
            {
                return await _pokemonDbContext.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public virtual async Task<T> GetSingleByExpressionAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                return await _pokemonDbContext.Set<T>().SingleOrDefaultAsync(expression);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public virtual IEnumerable<T> GetAll()
        {
            try
            {
                return _pokemonDbContext.Set<T>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public virtual async Task<IEnumerable<T>> GetByExpressionAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                return await _pokemonDbContext.Set<T>().AsQueryable().Where(expression).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException($"{nameof(Delete)} entity must not be null");
                }
                _pokemonDbContext.Set<T>().Remove(entity);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public virtual void DeleteById(int id)
        {
            try
            {
                var entity = _pokemonDbContext.Set<T>().FirstOrDefault(e => e.Id == id);
                if (entity != null)
                {
                    Delete(entity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

    }
}
