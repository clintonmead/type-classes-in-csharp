using System;

namespace TypeClasses
{
    public static class Traversable
    {
        public static TypeApp<TTraversable, TB> Traverse<TTraversable, TApplicative, TA, TB>(
            Func<TA, ITypeApp<TApplicative, TB>> f,
            ITypeApp<TTraversable, TA> x)
            where TApplicative : IApplicative<TApplicative>, new()
            where TTraversable : ITraversable<TTraversable>, new()
        {
            return new TTraversable().Traverse(f, x);
        }
    }
}
