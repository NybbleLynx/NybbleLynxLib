using System;
using System.Linq;
using System.Reflection;

namespace NybbleLynx.Lib.Core.Extensions
{
    public static class TypeExtensions
    {
        public static bool Implements<T>(this Type type) => typeof(T).IsAssignableFrom(type);

        public static bool HasDefaultConstructor(this Type type)
        {
            var constructors = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public);
            return constructors.Any(ctor => !ctor.GetParameters().Any());
        }

        public static TInstance BuildDefaultInstance<TInstance>(this Type type)
            where TInstance : class
        {
            var constructor = type.GetConstructor(Type.EmptyTypes) ?? throw new InvalidOperationException("Type must have a default constructor");

            var instance = constructor.Invoke(Array.Empty<object>());
            if (instance is not TInstance defaultInstance)
            {
                throw new InvalidOperationException($"Type must be an implementation of {typeof(TInstance)}");
            }

            return defaultInstance;
        }
    }
}