using System;

namespace AppController.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter
        , AllowMultiple = false, Inherited = true)]
    public class InjectedAttribute : Attribute
    {
        private readonly Type _moduleType;

        public InjectedAttribute()
        {}

        public InjectedAttribute(Type moduleType)
        {
            _moduleType = moduleType;
        }
        public Type ModuleType
        {
            get { return _moduleType; }
        }
    }
}
