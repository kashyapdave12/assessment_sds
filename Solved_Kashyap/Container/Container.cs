using System;
using System.Collections.Generic;

namespace DeveloperSample.Container
{
    public class Container
    {
        private readonly Dictionary<Type, Type> _bindings = new Dictionary<Type, Type>();
        private readonly Dictionary<Type, object> _instances = new Dictionary<Type, object>();

        public void Bind(Type interfaceType, Type implementationType)
        {
            if (!interfaceType.IsAssignableFrom(implementationType))
                throw new ArgumentException("Implementation type must be assignable to the interface type.");

            _bindings[interfaceType] = implementationType;
        }

        public T Get<T>()
        {
            return (T)Get(typeof(T));
        }

        private object Get(Type type)
        {
            if (_instances.ContainsKey(type))
            {
                return _instances[type];
            }

            Type implementationType;
            if (_bindings.ContainsKey(type))
            {
                implementationType = _bindings[type];
            }
            else if (type.IsInterface || type.IsAbstract)
            {
                throw new InvalidOperationException("No binding for type " + type.FullName);
            }
            else
            {
                implementationType = type;
            }

            var constructor = implementationType.GetConstructors()[0];
            var parameters = constructor.GetParameters();
            var parameterInstances = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                parameterInstances[i] = Get(parameters[i].ParameterType);
            }

            var implementationInstance = Activator.CreateInstance(implementationType, parameterInstances);
            _instances[type] = implementationInstance;
            return implementationInstance;
        }
    }
}
