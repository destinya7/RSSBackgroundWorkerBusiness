using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using RSSBackgroundWorkerBusiness.DAL;
using RSSBackgroundWorkerBusiness.Models;

namespace RSSBackgroundWorkerBusiness.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        private RSSContext _context = null;
        private DbSet<T> _table = null;

        public GenericRepository(RSSContext context)
        {
            this._context = context;
            this._table = _context.Set<T>();
        }

        public Task<List<T>> GetAll()
        {
            return _table.ToListAsync();
        }

        public Task<T> GetById(object id)
        {
            return _table.FindAsync(id);
        }

        public void Insert(T obj)
        {
            obj.DateCreated = DateTime.Now;
            obj.DateModified = DateTime.Now;
            _table.Add(obj);
        }

        public void Update(T obj)
        {
            obj.DateModified = DateTime.Now;
            _table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public async void Delete(object id)
        {
            T existing = await _table.FindAsync(id);
            _table.Remove(existing);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }
    }
}
