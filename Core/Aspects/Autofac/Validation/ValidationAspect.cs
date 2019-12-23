using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;

        public ValidationAspect(Type validatorType)
        {
            // Gönderilen validatorType IValidator tipinde mi?
            if (typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception(AsspectMessages.WrongValidationType);
            }

            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);

            // Entity i bulduk. Örn; Product
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];

            // Entity nin fieldlarını aldık. Örn; ProductName,..
            var entities = invocation.Arguments.Where(t=>t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
