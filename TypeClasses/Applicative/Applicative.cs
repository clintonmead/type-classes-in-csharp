using System;

namespace TypeClasses
{
    public static class Applicative<TApplicative> where TApplicative : IApplicative<TApplicative>, new()
    {
        public static TypeApp<TApplicative,T> Pure<T>(T x)
        {
            return new TApplicative().Pure(x);
        }
    }

    public static class Applicative
    {
        public static TypeApp<TApplicative, TOut> Ap<TApplicative, TIn, TOut>(
            ITypeApp<TApplicative, Func<TIn, TOut>> f,
            ITypeApp<TApplicative, TIn> x) 
            where TApplicative : IApplicative<TApplicative>, new()
        {
            return new TApplicative().Ap(f, x);
        }

        public static TypeApp<TApplicative, TOut> Ap<TApplicative, TIn, TOut>(
            this ITypeApp<TApplicative, TIn> x,
            ITypeApp<TApplicative, Func<TIn, TOut>> f)
            where TApplicative : IApplicative<TApplicative>, new()
        {
            return Ap(f, x);
        }
    }
}
