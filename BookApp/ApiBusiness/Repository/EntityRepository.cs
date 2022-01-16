 using ApiBusiness.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiBusiness.Repository
{
    public abstract class EntityRepository<TContext, TEntity> : IRepository<TEntity> where TContext : DbContext where TEntity: class,IEntity
    {
        public TContext Context { get; set; }
        public EntityRepository(TContext context)
        {
            this.Context = context;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            if (entity != null && entity != default)
            {
                this.Context.Set<TEntity>().Add(entity);
                await this.Context.SaveChangesAsync();
                return entity;
            }
            else
                return null;
        }
        /// <summary>
        /// Async Update existing data
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity != null && entity != default)
            {
                this.Context.Entry(entity).State = EntityState.Modified;
                await this.Context.SaveChangesAsync();
                return entity;
            }
            else
                return null;
        }
        /// <summary>
        /// Async Delete Data By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> DeleteAsync(string id)
        {
            if(id!=null)
            {
                TEntity data = await this.Context.Set<TEntity>().FindAsync(id);
                if(data!=null && data!=default)
                {
                    this.Context.Set<TEntity>().Remove(data);
                    this.Context.Entry(data).State = EntityState.Deleted;
                    await this.Context.SaveChangesAsync();
                    return data;
                }
            }
            return null;
        }
        /// <summary>
        /// Async Get All data
        /// </summary>
        /// <returns></returns>
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await this.Context.Set<TEntity>().ToListAsync();
        }
        /// <summary>
        /// Asyncronus Get By Object property key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> GetByIdAsync(string id)
        {
            if (id != null)
            {
                return await this.Context.Set<TEntity>().FindAsync(id);
            }
            else 
                return null;
        }
        /// <summary>
        /// Asynconus GetAsNoTracking : GET and relase context
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> GetByIdAsNoTrackingAsync(string id)
        {
            if (id != null)
            {
                var entity = await this.Context.Set<TEntity>().FindAsync(id);
                Context.Entry(entity).State = EntityState.Detached;
                return entity;
            }
            else
                return null;
        }
    }
}
