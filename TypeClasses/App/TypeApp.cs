using System.Collections.Generic;

namespace TypeClasses
{
    public class TypeApp<TConstructor, TType> : ITypeApp<TConstructor, TType>
    {
        private readonly object _underlying;

        public TypeApp(object underlying)
        {
            _underlying = underlying;
        }

        public object UnderlyingObject
        {
            get { return _underlying; }
        }

        public static implicit operator TypeApp<TConstructor, TType>(TypeAppProxy x)
        {
            return new TypeApp<TConstructor, TType>(x.Value);
        }
    }

    public static class TypeApp
    {
        public static TypeAppProxy Create(object x)
        {
            return new TypeAppProxy(x);
        }        
    }
}
