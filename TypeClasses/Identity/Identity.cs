using System;

namespace TypeClasses
{
    public class Identity<T> : IIdentity<T>, ITypeApp<IdentityTypeCon, T>
    {
        private readonly T _value;

        public Identity(T value)
        {
            _value = value;
        }

        public static implicit operator Identity<T>(T x)
        {
            return new Identity<T>(x);
        }

        public T Value
        {
            get { return _value; }
        }

        public object UnderlyingObject
        {
            get { return this; }
        }

        public static implicit operator Identity<T>(TypeApp<IdentityTypeCon, T> x)
        {
            return x.FromTypeApp();
        }

        public static implicit operator TypeApp<IdentityTypeCon, T>(Identity<T> x)
        {
            return TypeApp.Create(x);
        }
    }

    public static class Identity
    {
        public static Identity<T> Create<T>(T x)
        {
            return new Identity<T>(x);
        }

        public static Identity<TOut> FMap<TIn, TOut>(Func<TIn,TOut> f, IIdentity<TIn> x)
        {
            return Create(f(x.Value));
        }

        public static Identity<T> FromTypeApp<T>(this ITypeApp<IdentityTypeCon, T> x)
        {
            return (Identity<T>) x.UnderlyingObject;
        }

        public static Identity<T> ToIdentity<T>(this T x)
        {
            return Identity.Create(x);
        }
    }
}
