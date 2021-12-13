
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    { //bir metodun nasıl yorumlacağını anlattığımız yer
        protected virtual void OnBefore(IInvocation invocation) { } // invocation metodu temsil eder. OnBefore, method çalışmadan çalışır
        protected virtual void OnAfter(IInvocation invocation) { } // method çalıştıktan sonra çalışır
        protected virtual void OnException(IInvocation invocation, System.Exception e) { } // method hata verdiğinde çalışır
        protected virtual void OnSuccess(IInvocation invocation) { } // method başarılıysa çalışır

        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed(); // methodu çalıştır demek.
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}
