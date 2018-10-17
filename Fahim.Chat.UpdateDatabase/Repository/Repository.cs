using Fahim.Chat.UpdateDatabase.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahim.Chat.UpdateDatabase.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly FahimChatContext _context;

        //private readonly string _connectionString;

        public Repository()
        {
            _context = new FahimChatContext();
        }

        public IQueryable<T> All => throw new NotImplementedException();

        public void Delete(Guid id)
        {
            _context.Set<T>().Remove(Find(id));
        }

        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public T Find(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T> FindAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<Users> FindByIdentifierAsync(int id)
        {
            return await _context.Set<Users>().FirstOrDefaultAsync(s=>s.IdentifierNumber ==id);
        }
        public void Insert(T model)
        {
             _context.Set<T>().Add(model);
        }
        public async Task InsertAsync(T model)
        {
           await _context.Set<T>().AddAsync(model);
        }

        public IDbConnection OpenConnection()
        {
            throw new NotImplementedException();
        }

        public void Query(string query)
        {
            _context.Database.ExecuteSqlCommand(query);
        }

        public void SaveToDb()
        {
            _context.SaveChanges();
        }

        public  IQueryable<T> GetAll()
        {

           return   _context.Set<T>();
        }

        public async Task<bool> SaveToDbAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Add logging here. What to do with ex?!
                return false;
            }
            return true;

        }

        public void Update(T model)
        {
            _context.Entry(model).State = EntityState.Modified;


        }
        private bool _disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
    
    }
}
