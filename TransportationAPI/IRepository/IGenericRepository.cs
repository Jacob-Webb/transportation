using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TransportationAPI.IRepository
{
    /// <summary>
    /// A generic interface that defines basic CRUD operations.
    /// </summary>
    /// <remarks>
    /// Learn more about the Generic Repository Pattern <see href="https://dotnettutorials.net/lesson/generic-repository-pattern-csharp-mvc/">HERE</see>.
    /// </remarks>
    /// <typeparam name="T">The base item type. Must be a <c>class</c>.</typeparam>
    public interface IGenericRepository<T>
        where T : class
    {
        /// <summary>
        /// Return all instances in the set of type <typeparamref name="T"/> that matches the parameters.
        /// </summary>
        /// <param name="expression">An <see cref="Expression"/> used as a query for objects of type <typeparamref name="T"/>.</param>
        /// <param name="orderBy">A <see cref="Func{T, TResult}"/> used to order the query results.</param>
        /// <param name="include">A <see cref="Func{T, TResult}"/> to include parameters in the query.</param>
        /// <returns>A Generic List of type <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IList<T>> GetAllAsync(
                   Expression<Func<T, bool>> expression = null,
                   Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                   Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

        /// <summary>
        /// Return an instance of from the set of type <typeparamref name="T"/> that matches the parameters.
        /// </summary>
        /// <param name="expression">An <see cref="Expression"/> used as a query for objects of type <typeparamref name="T"/>.</param>
        /// <param name="include">A <see cref="Func{T, TResult}"/> to include parameters in the query.</param>
        /// <returns>An instance of <see cref="Task{TResult}"/> representing the result.</returns>
        Task<T> GetAsync(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

        /// <summary>
        /// Creates an entity of type <typeparamref name="T"/> in a repository.
        /// </summary>
        /// <param name="entity">An instance of type <typeparamref name="T"/> to be created in the repository.</param>
        /// <returns>An instance of type <see cref="Task"/>.</returns>
        Task InsertAsync(T entity);

        /// <summary>
        /// Creates instances of an entity of type <typeparamref name="T"/> from a collection.
        /// </summary>
        /// <param name="entities">A collection of entities of type <see cref="IEnumerable{T}"/>.</param>
        /// <returns>An instance of type <see cref="Task"/>.</returns>
        Task InsertRangeAsync(IEnumerable<T> entities);

        /// <summary>
        /// Removes from a repository an entity whose id matches the given parameter.
        /// </summary>
        /// <param name="id">An <c>int</c> representing an entity's id.</param>
        /// <returns>An instance of type <see cref="Task"/>.</returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Removes from a repository a collection of entities.
        /// </summary>
        /// <param name="entities">A collection of entities to be removed from a repository.</param>
        void DeleteRange(IEnumerable<T> entities);

        /// <summary>
        /// Updates an entity's data in a repository.
        /// </summary>
        /// <param name="entity">An instance of type <typeparamref name="T"/> to be updates.</param>
        void Update(T entity);
    }
}
