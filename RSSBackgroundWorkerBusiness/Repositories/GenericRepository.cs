using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using RSSBackgroundWorkerBusiness.Models;

namespace RSSBackgroundWorkerBusiness.Repositories
{
    public class GenericRepository<TContext, TEntity> : IGenericRepository<TEntity>
        where TContext : DbContext
        where TEntity : BaseModel
    {
        private readonly TContext _context = null;
        protected DbSet<TEntity> Table = null;

        public GenericRepository(TContext context)
        {
            this._context = context;
            this.Table = _context.Set<TEntity>();
        }

        public Task<List<TEntity>> GetAll()
        {
            return Table.ToListAsync();
        }

        public Task<TEntity> GetById(object id)
        {
            return Table.FindAsync(id);
        }

        public void Insert(TEntity obj)
        {
            obj.DateCreated = DateTime.Now;
            obj.DateModified = DateTime.Now;
            Table.Add(obj);
        }

        public void Update(TEntity obj)
        {
            obj.DateModified = DateTime.Now;
            Table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public async void Delete(object id)
        {
            TEntity existing = await Table.FindAsync(id);
            Table.Remove(existing);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }
    }
}
