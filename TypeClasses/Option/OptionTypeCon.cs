using System;

namespace TypeClasses
{
    public struct OptionTypeCon : IMonad<OptionTypeCon>, ITraversable<OptionTypeCon>
    {
        public TypeApp<OptionTypeCon, TOut> FMap<TOut, TIn>(Func<TIn, TOut> f, ITypeApp<OptionTypeCon, TIn> x)
        {
            return Option.FMap(f, x.FromTypeApp());
        }

        public TypeApp<OptionTypeCon, TOut> Bind<TIn, TOut>(ITypeApp<OptionTypeCon, TIn> x, Func<TIn, ITypeApp<OptionTypeCon, TOut>> f)
        {
            return Option.Bind(x.FromTypeApp(), val => f(val).FromTypeApp());
            
        }

        public TypeApp<OptionTypeCon, T> Pure<T>(T x)
        {
            return Option.Create(x);
        }

        public TypeApp<OptionTypeCon, TOut> Ap<TIn, TOut>(ITypeApp<OptionTypeCon, Func<TIn, TOut>> f, ITypeApp<OptionTypeCon, TIn> x)
        {
            return Option.Ap(f.FromTypeApp(), x.FromTypeApp());
        }

        public TypeApp<OptionTypeCon, TB> Traverse<TApplicative, TA, TB>(Func<TA, ITypeApp<TApplicative, TB>> f, ITypeApp<OptionTypeCon, TA> x) where TApplicative : IApplicative<TApplicative>, new()
        {
            throw new NotImplementedException();
        }

        public TB Foldr<TA, TB>(Func<TA, TB, TB> f, TB z, ITypeApp<OptionTypeCon, TA> x)
        {
            throw new NotImplementedException();
        }
    }
}
