using System;

namespace TypeClasses
{
    public static class Functor
    {
        public static TypeApp<TFunctor, TOut> FMap<TFunctor, TOut, TIn>(
            Func<TIn, TOut> f, 
            ITypeApp<TFunctor, TIn> x)
            where TFunctor : IFunctor<TFunctor>, new()
        {
            return new TFunctor().FMap(f, x);
        }

        public static TypeApp<TFunctor, TOut> FMap<TFunctor, TOut, TIn>(this ITypeApp<TFunctor, TIn> x, Func<TIn, TOut> f)
            where TFunctor : IFunctor<TFunctor>, new()
        {
            return FMap(f, x);
        }

        public static TypeApp<TFunctor, TOut> FMapConst<TFunctor, TOut, TIn>(TOut c, ITypeApp<TFunctor, TIn> x)
            where TFunctor : IFunctor<TFunctor>, new()
        {
            TFunctor functor = new TFunctor();
            IFunctorConst<TFunctor> functorConst = functor as IFunctorConst<TFunctor>;
            if (functorConst != null)
            {
                return functorConst.FMapConst(c, x);
            }
            else
            {
                return functor.FMap(ignore => c, x);
            }
        }

        public static void Test()
        {
            Option<int> y = Option.Create(1);

            Option<int> result = FMap(x => x, y);

        }
    }
}
