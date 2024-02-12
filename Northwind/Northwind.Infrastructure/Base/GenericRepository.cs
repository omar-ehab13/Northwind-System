using Microsoft.EntityFrameworkCore;
using Northwind.Core.Helpers.Logger;
using Northwind.Infrastructure.Data;
using System.Linq.Expressions;

namespace Northwind.Infrastructure.Base
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        #region Private Fields
        private readonly NorthwindContext _context;
        private readonly ILoggerManager _logger;
        private readonly DbSet<TEntity> dbSet;
        #endregion

        #region Constructor
        public GenericRepository(NorthwindContext context, ILoggerManager logger)
        {
            this._context = context;
            this._logger = logger;
            this.dbSet = context.Set<TEntity>();
        }
        #endregion

        #region Methods For Create
        public async Task<bool> CreateAsync(TEntity entity)
        {
            try
            {
                await dbSet.AddAsync(entity);

                _logger.LogInfo($"Adding a new {typeof(TEntity).Name} record");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogInfo(ex.StackTrace);
                return false;
            }
        }

        public async Task<bool> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            try
            {
                await dbSet.AddRangeAsync(entities);

                _logger.LogInfo($"Adding a new multiple {typeof(TEntity).Name} records");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogInfo(ex.StackTrace);
                return false;
            }
        }
        #endregion

        #region Update and Delete
        public async Task<bool> UpdateAsync(TEntity oldEntity, TEntity newEntity)
        {
            try
            {
                _context.Entry(oldEntity).CurrentValues.SetValues(newEntity);

                _logger.LogInfo($"Updaing {typeof(TEntity).Name} record");

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogInfo(ex.StackTrace);

                return false;
            }
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            try
            {
                var entry = _context.Entry(entity);

                if (entry.State == EntityState.Modified)
                {
                    // get primary keys values for the entity
                    var keyProperties = _context.Model.FindEntityType(typeof(TEntity))!.FindPrimaryKey()!.Properties;
                    var keyPropertiesValues = keyProperties.Select(p => p.GetGetter().GetClrValue(entity))
                                                            .ToArray();

                    // search for existing entity
                    var existingEntity = await _context.Set<TEntity>().FindAsync(keyPropertiesValues);

                    // if the entity with primary keys is exist change properties values
                    if (existingEntity != null)
                    {
                        var existingEntry = _context.Entry(existingEntity);
                        existingEntry.CurrentValues.SetValues(entity);
                    }
                    // if the entity with primary keys is not exist attach new entity with new values
                    else
                    {
                        _context.Attach(entity);
                        entry.State = EntityState.Modified;
                    }

                    _logger.LogInfo($"Updaing {typeof(TEntity).Name} record");

                    return true;
                }

                _logger.LogWarn($"Failed to update {typeof(TEntity).Name} record");
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogInfo(ex.StackTrace);

                return false;
            }
        }

        public async Task<bool> RemoveAsync(TEntity entity)
        {
            try
            {

                dbSet.Remove(entity);

                return await Task.FromResult(true);
            }
            catch
            {
                return false;
            }
        }


        public async Task<bool> RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            try
            {
                dbSet.RemoveRange(entities);

                return await Task.FromResult(true);
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Get Direct Data
        public async Task<IQueryable<TEntity>> GetAllAsync(bool trackChanges = true)
        {
            try
            {
                var query = trackChanges ?
                    await Task.FromResult(dbSet.AsTracking()) :
                    await Task.FromResult(dbSet.AsNoTracking());

                _logger.LogInfo($"Getting all {typeof(TEntity).Name} records");

                return query;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogInfo(ex.StackTrace);
                return null!;
            }
        }

        public async Task<TEntity?> GetByIdAsync<TId>(TId id)
        {
            try
            {
                var entity = await dbSet.FindAsync(id);
                _logger.LogInfo($"Finding {typeof(TEntity).Name} record");

                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
        #endregion

        #region Find with Filter
        public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, string[]? includes = null, bool trackChanges = true)
        {
            IQueryable<TEntity> query = trackChanges ? dbSet : dbSet.AsNoTracking();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<IQueryable<TEntity>> FindAllWithIncludes(string[] includes, bool trackChanges = true)
        {
            IQueryable<TEntity> query = trackChanges ? dbSet : dbSet.AsNoTracking();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await Task.FromResult(query);
        }

        public async Task<IQueryable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, string[]? includes = null, bool trackChanges = true)
        {
            IQueryable<TEntity> query = trackChanges ? dbSet : dbSet.AsNoTracking();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await Task.FromResult(query.Where(predicate));
        }

        #endregion

        #region Statistics and Aggregate
        public async Task<int> CountAsync()
        {
            return await dbSet.CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await dbSet.CountAsync(expression);
        }

        public async Task<decimal> SumAsync(Expression<Func<TEntity, decimal>> expression)
        {
            return await dbSet.SumAsync(expression);
        }

        public async Task<decimal> AverageAsync(Expression<Func<TEntity, decimal>> expression)
        {
            return await dbSet.AverageAsync(expression);
        }

        public async Task<decimal> MinAsync(Expression<Func<TEntity, decimal>> expression)
        {
            return await dbSet.MinAsync(expression);
        }

        public async Task<decimal> MaxAsync(Expression<Func<TEntity, decimal>> expression)
        {
            return await dbSet.MaxAsync(expression);
        }
        #endregion
    }
}
