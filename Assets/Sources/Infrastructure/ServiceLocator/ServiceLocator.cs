using System;
using System.Collections.Generic;

namespace Sources.Infrastructure.ServiceLocator
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> Instances = new();

        public static void Clear()
        {
            Instances.Clear();
        }
        
        public static void Register<TContract>(TContract instance)
        where TContract : class
        {
            if (!Instances.TryAdd(typeof(TContract), instance))
                throw new ArgumentException($"An instance of this type: {typeof(TContract)} is already registered.");
        }

        public static void Register(Type type, object instance)
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));

            if (!Instances.TryAdd(type, instance))
                throw new ArgumentException($"An instance of this type: {type} is already registered.");
        }

        public static TInstance GetInstance<TInstance>()
            where TInstance : class
        {
            if (!Instances.TryGetValue(typeof(TInstance), out var instance))
                throw new ArgumentException($"An instance of this type: {typeof(TInstance)} is not registered.");

            return instance as TInstance;
        }
    }
}