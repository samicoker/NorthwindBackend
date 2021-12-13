
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect:MethodInterception
    {
        Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType)) 
            { // gönderilen validatorType, bir IValidator türünde değilse bu if bloğu çalışır
                throw new System.Exception(AspectMessages.WrongValidationType);
            }
            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); // reflection yöntemiyle instance ürettik. ProductValidatoru newledik yani.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; // producta ulaştık. validatorTypenin BaseType'si AbstractValidatordür, onun generiğinde de product var. [0] ise tek 1 tane object olduğu için
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); // metodun parametrelerini yukarıdaki entityType e göre filtreledik

            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);  // 1 den fazla parametre varsa hepsini tek tek kullanmak için  yazdık
            }
        }
    }
}
