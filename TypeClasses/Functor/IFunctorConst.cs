using System;

namespace TypeClasses
{
    public interface IFunctorConst<TFunctor> : IFunctor<TFunctor>
    {
        TypeApp<TFunctor, TOut> FMapConst<TOut, TIn>(TOut c, ITypeApp<TFunctor, TIn> x);
    }
}
