using System;
using System.Reflection;
using Fixie;
using Ploeh.AutoFixture;
using Fixture = Fixie.Fixture;

namespace Practice.Configuration
{
    public static class BehaviorBuilderExtensions
    {
        public static void TryField(this Fixture context, string fieldName, object fieldValue)
        {
            var lifecycleMethod = context.Class.Type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);

            if (lifecycleMethod == null)
                return;

            try
            {
                lifecycleMethod.SetValue(context.Instance, fieldValue);
            }
            catch (TargetInvocationException exception)
            {
                throw new PreservedException(exception.InnerException);
            }
        }

        public static void TryInvoke(this Type type, string method, object instance, IFixture fixture = null)
        {
            var lifecycleMethod = type.GetMethod(method);
            //                type.GetMethods(BindingFlags.Public | BindingFlags.Instance)
            //                    .SingleOrDefault(x => ReflectionExtensions.HasSignature(x, typeof(void), method));

            if (lifecycleMethod == null)
                return;

            try
            {
                if (fixture == null)
                {
                    lifecycleMethod.Invoke(instance, null);
                }
                else
                {
                    lifecycleMethod.Invoke(instance, new object[]
                    {
                        fixture
                    });
                }
            }
            catch (TargetInvocationException exception)
            {
                throw new PreservedException(exception.InnerException);
            }
        }
    }
}