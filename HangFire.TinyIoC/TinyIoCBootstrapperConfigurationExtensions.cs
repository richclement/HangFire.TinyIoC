using Hangfire;
using TinyIoC;

namespace HangFire.TinyIoC
{
    public static class TinyIoCBootstrapperConfigurationExtensions
    {
        /// <summary>
        /// Tells bootstrapper to use the specified TinyIoC container as a global job activator.
        /// </summary>
        /// <param name="configuration">Configuration</param>
        /// <param name="container">TinyIoC container that will be used to activate jobs</param>
        public static void UseTinyIoCActivator(
            this IBootstrapperConfiguration configuration,
            TinyIoCContainer container)
        {
            configuration.UseActivator(new TinyIoCJobActivator(container));
        }
    }
}
