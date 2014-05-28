using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentApplication.Interceptors
{
    public class LoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            System.Diagnostics.Debug.Write("this is what's passed before the invocation of the repository with method " +
                invocation.Method.Name);
            foreach (object arg in invocation.Arguments)
            {
                System.Diagnostics.Debug.Write(" argument: " + arg);
            }
            System.Diagnostics.Debug.WriteLine(" target type: " + invocation.TargetType);
            invocation.Proceed();
            System.Diagnostics.Debug.WriteLine("result: " + invocation.ReturnValue);
        }
    }
}