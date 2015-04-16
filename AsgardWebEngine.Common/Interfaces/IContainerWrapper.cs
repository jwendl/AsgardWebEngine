
namespace AsgardWebEngine.Common.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IContainerWrapper
    {
        /// <summary>
        /// Resolves this instance.
        /// </summary>
        /// <typeparam name="T">The type of the input.</typeparam>
        /// <returns></returns>
        T Resolve<T>();

        /// <summary>
        /// Registers all instances.
        /// </summary>
        void RegisterAllInstances();
    }
}
