using System;

namespace TypeClasses
{
    public interface ITraversable<TTraversable> : IFunctor<TTraversable>, IFoldable<TTraversable>
    {
        TypeApp<TTraversable, TB> Traverse<TApplicative, TA, TB>(
            Func<TA, ITypeApp<TApplicative, TB>> f,
            ITypeApp<TTraversable, TA> x) where TApplicative : IApplicative<TApplicative>, new();
    }
}
