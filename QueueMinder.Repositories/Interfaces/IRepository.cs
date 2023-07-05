using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QueueMinder.Domain.Interfaces;
using QueueMinder.Domain.Models;

namespace QueueMinder.Repositories.Interfaces
{
    //defines the contract/model for the database 
    public interface IRepository: IDisposable
    {
        DbSet<ManagedQueue> Queue { get; set; }
        DbSet<QueueMember> QueueMembers { get; set; }


        /// <summary>
        /// Add new entity to the repository
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void Add<T>(T entity) where T : class, IBaseClass;

        /// <summary>
        /// Delete specified entity of type T from the repository
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void Delete<T>(T entity) where T : class;

        /// <summary>
        /// Query entities of type T from the repository with specific included references
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="includeReferences">Any references that need to be returned with the query</param>
        /// <returns>A queryable set of objects</returns>
        IQueryable<T> Q<T>(params string[] includeReferences) where T : class;

        /// <summary>
        /// Get specific entity of type T with the provided identifier
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get<T>(int id) where T : class, IBaseClass;

        /// <summary>
        /// Execute the named stored procedure
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IQueryable<T> SP<T>(string name, params object[] parameters) where T : class;

        /// <summary>
        /// Submit the changes to the data in the repository to the underlying data store
        /// </summary>
        /// <returns></returns>
        int Commit();

        /// <summary>
        /// Submit the changes to the data in the repository to the underlying data store
        /// </summary>
        /// <returns></returns>
        Task<int> CommitAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancel uncommitted changes
        /// </summary>
        void RollBack();
    }
}
