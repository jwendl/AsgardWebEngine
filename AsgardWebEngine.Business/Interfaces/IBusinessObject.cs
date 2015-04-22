
using AsgardWebEngine.Business.Exceptions;
using System.Collections.Generic;
namespace AsgardWebEngine.Business.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBusinessObject
    {
        /// <summary>
        /// Gets a value indicating whether this instance is new.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is new; otherwise, <c>false</c>.
        /// </value>
        bool IsNew { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        bool IsValid { get; }

        /// <summary>
        /// Gets the errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        IEnumerable<ValidationException> Errors { get; }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        void Validate();
    }
}
