using AsgardWebEngine.Common.Interfaces;
using Castle.Windsor;

namespace AsgardWebEngine.Business.Framework
{
    /// <summary>
    /// An IoC container wrapper for castle windsor.
    /// </summary>
    public class WindsorContainerWrapper
        : IContainerWrapper
    {
        private IWindsorContainer windsorContainer { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WindsorContainerWrapper"/> class.
        /// </summary>
        public WindsorContainerWrapper(IWindsorContainer windsorContainer)
        {
            this.windsorContainer = windsorContainer;
        }

        /// <summary>
        /// Resolves this instance.
        /// </summary>
        /// <typeparam name="T">The type of the input.</typeparam>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public T Resolve<T>()
        {
            return windsorContainer.Resolve<T>();
        }

        /// <summary>
        /// Registers all instances.
        /// </summary>
        public void RegisterAllInstances()
        {

        }
    }
}
