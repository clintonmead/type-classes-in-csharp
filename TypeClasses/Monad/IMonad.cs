using System;

namespace TypeClasses
{
    public interface IMonad<TMonad> : IApplicative<TMonad>
    {
        TypeApp<TMonad, TOut> Bind<TIn, TOut>(ITypeApp<TMonad, TIn> x, Func<TIn, TypeApp<TMonad, TOut>> f);
    }
}
