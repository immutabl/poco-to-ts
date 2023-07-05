using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QueueMinder.Domain.Interfaces;
using QueueMinder.Domain.Models;
using QueueMinder.Repositories.Interfaces;

namespace QueueMinder.Repositories.Implementation
{
    public class Repository: DbContext, IRepository
    {
        public DbSet<ManagedQueue> Queue { get; set; }
        public DbSet<QueueMember> QueueMembers { get; set; }
        public new void Add<T>(T entity) where T : class, IBaseClass
        {
            entity.Created = DateTime.UtcNow;
            entity.CreatedBy = string.Empty; //get current user id for this

            Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            //logging here as required
            if (entity == null)
            {
                Debug.Assert(false, $"Attempted delete of null entity.");
            }

            Set<T>().Remove(entity);
        }

        public IQueryable<T> Q<T>(params string[] includeReferences) where T : class
        {
            throw new NotImplementedException();
        }

        public T Get<T>(int id) where T : class, IBaseClass
        {
            return Set<T>().FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<T> SP<T>(string name, params object[] parameters) where T : class
        {
            throw new NotImplementedException();
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }

        public Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void RollBack()
        {
            throw new NotImplementedException();
        }
    }
}
