using System;
using System.Runtime.Serialization;

namespace AsgardWebEngine.Business.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class ValidationException
        : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ValidationException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public ValidationException(string message, Exception exception)
            : base(message, exception)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException" /> class.
        /// </summary>
        /// <param name="serializationInfo">The serialization information.</param>
        /// <param name="streamingContext">The streaming context.</param>
        protected ValidationException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {

        }
    }
}
