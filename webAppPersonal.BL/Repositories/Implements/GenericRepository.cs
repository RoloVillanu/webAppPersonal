using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using webAppPersonal.BL.Data;

namespace webAppPersonal.BL.Repositories.Implements
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly webAppPersonalContext webappPersonalContext;

        public GenericRepository(webAppPersonalContext webappPersonalContext)
        {
            this.webappPersonalContext = webappPersonalContext;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
                throw new Exception("The entity is null");

            webappPersonalContext.Set<TEntity>().Remove(entity);
            await webappPersonalContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await webappPersonalContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await webappPersonalContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            webappPersonalContext.Set<TEntity>().Add(entity);
            await webappPersonalContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            //webappPersonalContext.Entry(entity).State = EntityState.Modified;
            webappPersonalContext.Set<TEntity>().AddOrUpdate(entity);
            await webappPersonalContext.SaveChangesAsync();
            return entity;
        }
    }
}
