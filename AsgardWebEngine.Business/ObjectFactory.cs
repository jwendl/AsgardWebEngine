using AsgardWebEngine.Business.Interfaces;
using AsgardWebEngine.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AsgardWebEngine.Business
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TBusinessObject">The type of the business object.</typeparam>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    public class ObjectFactory<TBusinessObject, TKey>
        : IObjectFactory<TBusinessObject, TKey>
        where TBusinessObject : class, IBusinessObject
    {
        private IContainerWrapper containerWrapper { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectFactory{TBusinessObject, TKey}" /> class.
        /// </summary>
        /// <param name="containerWrapper">The container wrapper.</param>
        public ObjectFactory(IContainerWrapper containerWrapper)
        {
            this.containerWrapper = containerWrapper;
        }

        /// <summary>
        /// Fetches the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public TBusinessObject Fetch(TKey key)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Fetches all.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<TBusinessObject> FetchAll()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Fetches all.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<TBusinessObject> FetchAll(Expression<Func<TBusinessObject, bool>> query)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public TBusinessObject Add(TBusinessObject item)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Adds the many.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<TBusinessObject> AddMany(IEnumerable<TBusinessObject> items)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Deletes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Delete(TBusinessObject item)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Deletes the many.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void DeleteMany(IEnumerable<TBusinessObject> items)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public TBusinessObject Update(TBusinessObject item)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Updates the many.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<TBusinessObject> UpdateMany(IEnumerable<TBusinessObject> items)
        {
            throw new System.NotImplementedException();
        }
    }
}
