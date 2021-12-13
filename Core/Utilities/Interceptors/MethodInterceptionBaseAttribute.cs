
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    //attribüte özellik verdik, 1.si classların üzerine konabilir, 2.si methotların başına konabilir, Allowmultiple ile 1.den fazla kullanılabilir, onu inherit edildiği alt classlarda da kullanabiliriz.
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    { // IInterceptor, Autofac'in de kullandığı bir dynamic proxy dir.
        public int Priority { get; set; } // aspectlere çalışma sırası vermek için bu değişkeni tanımladık
        public virtual void Intercept(IInvocation invocation)
        { // değiştirebilme imkanı vermek için biz virtual verdik

        }
    }
}
