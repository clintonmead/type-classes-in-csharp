using System;

namespace TypeClasses
{
    public struct IdentityTypeCon : IFunctor<IdentityTypeCon>
    {
        public TypeApp<IdentityTypeCon, TOut> FMap<TOut, TIn>(Func<TIn, TOut> f, ITypeApp<IdentityTypeCon, TIn> x)
        {
            return Identity.FMap(f, x.FromTypeApp());
        }
    }
}
