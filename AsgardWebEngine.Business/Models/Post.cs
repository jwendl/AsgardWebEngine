using AsgardWebEngine.Business.Interfaces;
using AsgardWebEngine.Data.Models;
using AsgardWebEngine.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsgardWebEngine.Business.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Post
        : IBusinessObject<Post, Guid>
    {
        private IMetadataRepository<PostEntity> postRepository { get; set; }

        private IDocumentRepository documentRepository { get; set; }

        public Post(IMetadataRepository<PostEntity> postRepository, IDocumentRepository documentRepository)
        {
            this.postRepository = postRepository;
            this.documentRepository = documentRepository;
        }

        /// <summary>
        /// Fetches the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Post Fetch(Guid key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fetches all.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<Post> FetchAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fetches all.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<Post> FetchAll(System.Linq.Expressions.Expression<Func<Post, bool>> query)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Post Add(Post item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds the many.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<Post> AddMany(IEnumerable<Post> items)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Delete(Post item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the many.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void DeleteMany(IEnumerable<Post> items)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Post Update(Post item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the many.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<Post> UpdateMany(IEnumerable<Post> items)
        {
            throw new NotImplementedException();
        }
    }
}
