using Fahim.Chat.UpdateDatabase.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahim.Chat.UpdateDatabase.Repository
{
    public interface IRepository<T> : IDisposable
    {
        IQueryable<T> All { get; }
        T Find(Guid id);
        Task<T> FindAsync(Guid id);
        void Insert(T model);
        Task InsertAsync(T model);
        Task<Users> FindByIdentifierAsync(int id);
        void Update(T model);

        void Delete(Guid id);

        void SaveToDb();

        Task<bool> SaveToDbAsync();

        void Delete(T item);

        void Query(string query);

        IQueryable<T> GetAll();

        IDbConnection OpenConnection();

    }
}
