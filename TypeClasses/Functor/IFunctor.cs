using System;

namespace TypeClasses
{
    public interface IFunctor<TFunctor>
    {
        TypeApp<TFunctor, TOut> FMap<TOut, TIn>(Func<TIn, TOut> f, ITypeApp<TFunctor, TIn> x);
    }
}
