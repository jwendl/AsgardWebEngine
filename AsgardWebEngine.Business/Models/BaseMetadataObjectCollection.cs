using AsgardWebEngine.Business.Framework;
using AsgardWebEngine.Business.Interfaces;
using AsgardWebEngine.Common;
using AsgardWebEngine.Data.Interfaces;
using AsgardWebEngine.Data.Repositories.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AsgardWebEngine.Business.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TBusinessObject">The type of the business object.</typeparam>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class BaseMetadataObjectCollection<TBusinessObject, TEntity>
        : IBusinessObjectCollection<TBusinessObject>
        where TBusinessObject : IBusinessObject<TBusinessObject>
        where TEntity : class, ITableEntity, new()
    {
        /// <summary>
        /// Gets or sets the metadata repository.
        /// </summary>
        /// <value>
        /// The metadata repository.
        /// </value>
        protected IMetadataRepository<TEntity> MetadataRepository { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseMetadataObjectCollection{TBusinessObject, TEntity}" /> class.
        /// </summary>
        /// <param name="metadataRepository">The metadata repository.</param>
        public BaseMetadataObjectCollection(IMetadataRepository<TEntity> metadataRepository)
        {
            this.MetadataRepository = metadataRepository;
        }

        /// <summary>
        /// Fetches the specified row key.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public TBusinessObject Fetch<TKey>(TKey key)
        {
            Args.IsOfType<TableStorageKey>(() => key);

            var tableStorageKey = key as TableStorageKey;
            var entity = MetadataRepository.Fetch(tableStorageKey.PartitionKey, tableStorageKey.RowKey);
            return Mapper.Map<TBusinessObject>(entity);
        }

        /// <summary>
        /// Fetches all.
        /// </summary>
        /// <returns></returns>
        public IBusinessObjectCollection<TBusinessObject> FetchAll()
        {
            return Mapper.Map<IBusinessObjectCollection<TBusinessObject>>(new List<TEntity>());
        }

        /// <summary>
        /// Fetches all.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IBusinessObjectCollection<TBusinessObject> Query(Expression<Func<TBusinessObject, bool>> expression)
        {
            return Mapper.Map<IBusinessObjectCollection<TBusinessObject>>(new List<TEntity>());
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            var entities = Mapper.Map<IEnumerable<TEntity>>(this);
            MetadataRepository.UpdateAll(entities);
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerator<TBusinessObject> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
