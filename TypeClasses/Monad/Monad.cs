using System;

namespace TypeClasses
{
    public static class Monad
    {
        public static TypeApp<TMonad, TOut> Bind<TMonad, TOut, TIn>(this ITypeApp<TMonad, TIn> x, Func<TIn, ITypeApp<TMonad, TOut>> f)
            where TMonad : IMonad<TMonad>, new()
        {
            return new TMonad().Bind(x, f);
        }

        public static TypeApp<TMonad, TOut> Bind<TMonad, TOut, TIn>(this ITypeApp<TMonad, TIn> x, ITypeApp<TMonad, TOut> c)
            where TMonad : IMonad<TMonad>, new()
        {
            return new TMonad().Bind(x, ignore => c);
        }

        public static TypeApp<TMonad, TResult> SelectMany<TMonad, TSource, TCollection, TResult>(
            this ITypeApp<TMonad, TSource> sourceMonad,
            Func<TSource, ITypeApp<TMonad, TCollection>> collectionSelector,
            Func<TSource, TCollection, TResult> resultSelector
        ) where TMonad : IMonad<TMonad>, new ()
        {
            return sourceMonad.Bind(source => collectionSelector(source).FMap(y => resultSelector(source, y)));
        }

        public static TypeApp<TFunctor, TResult> Select<TFunctor, TSource, TResult>(
            this ITypeApp<TFunctor, TSource> x, 
            Func<TSource, TResult> f
        ) where TFunctor : IFunctor<TFunctor>, new ()
        {
            return x.FMap(f);
        }
    }
}
