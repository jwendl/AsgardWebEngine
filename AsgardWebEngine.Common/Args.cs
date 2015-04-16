using System;
using System.Linq.Expressions;

namespace AsgardWebEngine.Common
{
    /// <summary>
    /// Handles argument inputs.
    /// </summary>
    public static class Args
    {
        /// <summary>
        /// Checks the argument null.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        public static void IsNotNull(params Expression<Func<Object>>[] expressions)
        {
            if (expressions != null)
            {
                foreach (var expression in expressions)
                {
                    if (expression.Compile().Invoke() == null)
                    {
                        throw new ArgumentNullException((expression.Body as MemberExpression).Member.Name);
                    }
                }
            }
        }

        /// <summary>
        /// Determines whether [is of type] [the specified expressions].
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="expressions">The expressions.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        public static void IsOfType<TObject>(params Expression<Func<Object>>[] expressions)
        {
            if (expressions != null)
            {
                foreach (var expression in expressions)
                {
                    if (expression.Compile().Invoke() == null)
                    {
                        throw new ArgumentNullException((expression.Body as MemberExpression).Member.Name);
                    }

                    if (expression.Compile().Invoke().GetType() != typeof(TObject))
                    {
                        throw new ArgumentException((expression.Body as MemberExpression).Member.Name);
                    }
                }
            }
        }
    }
}
