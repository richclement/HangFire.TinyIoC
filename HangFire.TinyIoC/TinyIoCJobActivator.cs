using System;
using TinyIoC;
using Hangfire;

namespace HangFire.TinyIoC
{
    /// <summary>
    /// HangFire job activator based on TinyIoC
    /// </summary>
    public class TinyIoCJobActivator : JobActivator
    {
        private readonly TinyIoCContainer _container;
        
        /// <summary>
        /// Initialize a new instance of the TinyIoCJobActivator with the given instance of a TinyIoC container
        /// </summary>
        /// <param name="container">container that will be used to instantiate classes during job activation</param>
        public TinyIoCJobActivator(TinyIoCContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");

            _container = container;
        }

        /// <inheritdoc />
        public override object ActivateJob(Type jobType)
        {
            return _container.Resolve(jobType);
        }
    }
}
