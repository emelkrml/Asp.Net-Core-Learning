using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using Core.CrossCuttingConcerns.Logging.Loggers;
using Core.Aspects.Autofac.Exception;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodINterceptionBaseAttribute>
                 (inherit: true).ToList();

            var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodINterceptionBaseAttribute>(inherit:true);
            classAttributes.AddRange(methodAttributes);
            classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
