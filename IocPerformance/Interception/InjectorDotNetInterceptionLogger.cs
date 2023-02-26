using System.Diagnostics;
using System.Linq;

using Solti.Utils.DI.Interfaces;

namespace IocPerformance.Interception
{
    public sealed class InjectorDotNetInterceptionLogger : IInterfaceInterceptor
    {
        public object Invoke(IInvocationContext context, Next<object> callNext)
        {
            // Perform logging here, e.g.:
            var args = string.Join(", ", context.Args.Select(x => (x ?? string.Empty).ToString()));
            Debug.WriteLine(string.Format("Autofac: {0}({1})", context.TargetMethod.Name, args));

            return callNext();
        }
    }

    public sealed class InjectorDotNetLoggerAspectAttribute : AspectAttribute
    {
        public InjectorDotNetLoggerAspectAttribute() : base(typeof(InjectorDotNetInterceptionLogger)) { }
    }
}
