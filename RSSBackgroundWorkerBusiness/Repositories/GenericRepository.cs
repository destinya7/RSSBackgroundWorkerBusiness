using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using RSSBackgroundWorkerBusiness.DAL;
using RSSBackgroundWorkerBusiness.Models;

namespace RSSBackgroundWorkerBusiness.Repositories
{
    public class GenericRepository<TContext, TEntity> : IGenericRepository<TEntity>
        where TContext : DbContext
        where TEntity : BaseModel
    {
        private readonly TContext _context = null;
        private DbSet<TEntity> _table = null;

        public GenericRepository(TContext context)
        {
            this._context = context;
            this._table = _context.Set<TEntity>();
        }

        public Task<List<TEntity>> GetAll()
        {
            return _table.ToListAsync();
        }

        public Task<TEntity> GetById(object id)
        {
            return _table.FindAsync(id);
        }

        public void Insert(TEntity obj)
        {
            obj.DateCreated = DateTime.Now;
            obj.DateModified = DateTime.Now;
            _table.Add(obj);
        }

        public void Update(TEntity obj)
        {
            obj.DateModified = DateTime.Now;
            _table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public async void Delete(object id)
        {
            TEntity existing = await _table.FindAsync(id);
            _table.Remove(existing);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }
    }
}
