using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed(); // metodu çalıştırmaya çalış
                    transactionScope.Complete(); // buraya geldiyse başarmıştır demek, işlemi kabul et
                }
                catch (System.Exception e)
                {
                    transactionScope.Dispose(); // yapılan işlemleri geri al
                    throw;
                }
            }
        }
    }
}
