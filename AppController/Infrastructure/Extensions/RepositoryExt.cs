using AppController.Core.Dynamic;
using System;
using System.Collections.Generic;

namespace AppController.Infrastructure.Extensions
{
    public static class RepositoryExt
    {
        public static List<IBinding> SearchBindings(this IBindingRepository bindingRepository, IEnumerable<Type> typeBindings)
        {
            List<IBinding> bindings = new List<IBinding>();

            foreach(Type bindingType in typeBindings)
            {
                IBinding binding = bindingRepository.GetBinding(bindingType);
                if (binding != null)
                    bindings.Add(binding);
            }

            return bindings;
        }
    }
}
