using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
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
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir dogrulama sinifi degildir");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            //tipe gore bir validator olustur, reflection
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //validator tipinin ilk generic argumanini entity tipin olarak al
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //businessdaki methoda git senin entity ne esit olan parametreyi al
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            // o entitylerin icerisinde gez ve dogrula.
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
