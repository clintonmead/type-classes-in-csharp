using System;

namespace TypeClasses
{
    public interface IApplicative<TApplicative> : IFunctor<TApplicative>
    {
        TypeApp<TApplicative, T> Pure<T>(T x);
        TypeApp<TApplicative, TOut> Ap<TIn, TOut>(ITypeApp<TApplicative, Func<TIn, TOut>> f, ITypeApp<TApplicative, TIn> x);
    }
}
