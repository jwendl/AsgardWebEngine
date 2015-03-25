using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AsgardWebEngine.Common.Tests
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class ArgsTests
    {
        /// <summary>
        /// Argumentses the is not null_ happy path.
        /// </summary>
        [TestMethod]
        public void ArgsIsNotNull_HappyPath()
        {
            var item = String.Empty;
            Args.IsNotNull(() => item);
        }

        /// <summary>
        /// Argumentses the is not null in happy path.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArgsIsNotNull_ExpectedException()
        {
            string item = null;
            Args.IsNotNull(() => item);
        }
    }
}
