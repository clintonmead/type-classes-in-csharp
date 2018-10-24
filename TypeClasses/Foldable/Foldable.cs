using System;

namespace TypeClasses
{
    public static class Foldable
    {
        public static TB Foldr<TFoldable, TA, TB>(
            Func<TA, TB, TB> f, 
            TB z,
            ITypeApp<TFoldable, TA> x) where TFoldable : IFoldable<TFoldable>, new()
        {
            return new TFoldable().Foldr(f, z, x);
        }
        public static TB Foldr<TFoldable, TA, TB>(
            this ITypeApp<TFoldable, TA> x,
            Func<TA, TB, TB> f, 
            TB z
            ) where TFoldable : IFoldable<TFoldable>, new()
        {
            return Foldr(f, z, x);
        }
    }
}
