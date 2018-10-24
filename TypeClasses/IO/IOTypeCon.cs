namespace TypeClasses
{
    public struct IOTypeCon : IMonad<IOTypeCon>
    {
        public TypeApp<IOTypeCon, TOut> Bind<TIn, TOut>(ITypeApp<IOTypeCon, TIn> x, System.Func<TIn, TypeApp<IOTypeCon, TOut>> f)
        {
            return IO.Bind(x.FromTypeApp(), val => f(val).FromTypeApp());
        }

        public TypeApp<IOTypeCon, T> Pure<T>(T x)
        {
            return IO.Pure(x);
        }

        public TypeApp<IOTypeCon, TOut> Ap<TIn, TOut>(ITypeApp<IOTypeCon, System.Func<TIn, TOut>> f, ITypeApp<IOTypeCon, TIn> x)
        {
            return IO.Ap(f.FromTypeApp(), x.FromTypeApp());
        }

        public TypeApp<IOTypeCon, TOut> FMap<TOut, TIn>(System.Func<TIn, TOut> f, ITypeApp<IOTypeCon, TIn> x)
        {
            return IO.FMap(f, x.FromTypeApp());
        }
    }
}
