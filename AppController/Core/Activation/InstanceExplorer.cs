using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace AppController.Core.Activation
{
    public static class InstanceExplorer
    {
        public static bool HasDefaultConstructor(Type instanceType)
        {
            if (!instanceType.IsClass)
                throw new ArgumentException();

            if(instanceType.GetConstructors().Count() == 1)
            {
                var parameters = instanceType.GetConstructors().First().GetParameters();

                return parameters.Count() == 0 || parameters.All(p => p.IsOptional);
            }

            return false;
        }
        public static ParameterInfo[] GetParameters(ConstructorInfo constructor)
        {
            return constructor.GetParameters();
        }
        public static ConstructorInfo[] GetOrderedConstructorList(Type instanceType)
        {
            return instanceType.GetConstructors().OrderByDescending(c => c.GetParameters().Count()).ToArray();
        }
        public static IEnumerable<ParameterInfo> GetNonOptionalParameters(ConstructorInfo constructor)
        {
            foreach (var parameter in GetParameters(constructor))
                if (!parameter.IsOptional)
                    yield return parameter;
        }
    }
}
