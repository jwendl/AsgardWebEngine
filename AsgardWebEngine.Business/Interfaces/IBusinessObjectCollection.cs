using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AsgardWebEngine.Business.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TBusinessObject">The type of the business object.</typeparam>
    public interface IBusinessObjectCollection<TBusinessObject>
        : IEnumerable<TBusinessObject>
        where TBusinessObject : IBusinessObject<TBusinessObject>
    {
        /// <summary>
        /// Fetches this instance.
        /// </summary>
        /// <returns></returns>
        TBusinessObject Fetch<TKey>(TKey key);

        /// <summary>
        /// Fetches all.
        /// </summary>
        /// <returns></returns>
        IBusinessObjectCollection<TBusinessObject> FetchAll();

        /// <summary>
        /// Fetches all.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        IBusinessObjectCollection<TBusinessObject> Query(Expression<Func<TBusinessObject, bool>> expression);

        /// <summary>
        /// Saves this instance.
        /// </summary>
        void Save();

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        Task SaveAsync();
    }
}
