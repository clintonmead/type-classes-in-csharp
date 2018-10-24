using System;

namespace TypeClasses
{
    public static class Monad
    {
        public static TypeApp<TMonad, TOut> Bind<TMonad, TOut, TIn>(this ITypeApp<TMonad, TIn> x, Func<TIn, TypeApp<TMonad, TOut>> f)
            where TMonad : IMonad<TMonad>, new()
        {
            return new TMonad().Bind(x, f);
        }

        public static TypeApp<TMonad, TResult> SelectMany<TMonad, TSource, TCollection, TResult>(
            this ITypeApp<TMonad, TSource> source,
            Func<TSource, ITypeApp<TMonad, TCollection>> collectionSelector,
            Func<TSource, TCollection, TResult> resultSelector
        ) where TMonad : IMonad<TMonad>, new ()
        {
            return source.Bind(x => collectionSelector(x).FMap(y => resultSelector(x, y)));
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
