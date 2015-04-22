using AsgardWebEngine.Business.Exceptions;
using AsgardWebEngine.Business.Interfaces;
using System;
using System.Collections.Generic;

namespace AsgardWebEngine.Framework.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseBusinessObject
        : IBusinessObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseBusinessObject"/> class.
        /// </summary>
        public BaseBusinessObject()
        {
            IsNew = true;
            IsValid = false;
            Errors = new List<ValidationException>();
        }

        /// <summary>
        /// Gets a value indicating whether this instance is new.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is new; otherwise, <c>false</c>.
        /// </value>
        public bool IsNew { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this instance is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        public bool IsValid { get; private set; }

        /// <summary>
        /// Gets the errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        public IEnumerable<ValidationException> Errors { get; private set; }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
