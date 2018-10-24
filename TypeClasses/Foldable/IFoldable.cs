using System;

namespace TypeClasses
{
    public interface IFoldable<in TFoldable>
    {
        TB Foldr<TA, TB>(Func<TA, TB, TB> f, TB z, ITypeApp<TFoldable, TA> x);
    }
}
