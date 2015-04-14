using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AsgardWebEngine.Business.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TBusinessObject">The type of the business object.</typeparam>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    public interface IObjectFactory<TBusinessObject, TKey>
        where TBusinessObject : class, IBusinessObject
    {
        /// <summary>
        /// Fetches the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        TBusinessObject Fetch(TKey key);

        /// <summary>
        /// Fetches all.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TBusinessObject> FetchAll();

        /// <summary>
        /// Fetches all.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        IEnumerable<TBusinessObject> FetchAll(Expression<Func<TBusinessObject, bool>> query);

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        TBusinessObject Add(TBusinessObject item);

        /// <summary>
        /// Adds the many.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        IEnumerable<TBusinessObject> AddMany(IEnumerable<TBusinessObject> items);

        /// <summary>
        /// Deletes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        void Delete(TBusinessObject item);

        /// <summary>
        /// Deletes the many.
        /// </summary>
        /// <param name="items">The items.</param>
        void DeleteMany(IEnumerable<TBusinessObject> items);

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        TBusinessObject Update(TBusinessObject item);

        /// <summary>
        /// Updates the many.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        IEnumerable<TBusinessObject> UpdateMany(IEnumerable<TBusinessObject> items);
    }
}
