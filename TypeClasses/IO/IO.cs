using System;

namespace TypeClasses
{
    public class IO<T> : ITypeApp<IOTypeCon, T>
    {
        private readonly Func<T> _ioFunc;

        public IO(Func<T> ioFunc)
        {
            _ioFunc = ioFunc;
        }

        public T RunIO()
        {
            return _ioFunc();
        }

        public TypeApp<IOTypeCon, T> ToTypeApp()
        {
            return TypeApp.Create(this);
        }

        public static implicit operator TypeApp<IOTypeCon, T>(IO<T> x)
        {
            return x.ToTypeApp();
        }

        public static implicit operator IO<T>(TypeApp<IOTypeCon, T> x)
        {
            return x.FromTypeApp();
        }

        public object UnderlyingObject
        {
            get { return this; }
        }
    }

    public static class IO
    {
        public static IO<T> Create<T>(Func<T> ioFunc)
        {
            return new IO<T>(ioFunc);
        }

        public static IO<T> Pure<T>(T val)
        {
            return Create(() => val);
        }

        public static IO<TOut> FMap<T, TOut>(Func<T, TOut> f, IO<T> x)
        {
            return Create(() => f(x.RunIO()));
        }

        public static IO<TOut> FMap<T, TOut>(this IO<T> x, Func<T, TOut> f)
        {
            return FMap(f, x);
        }

        public static IO<TOut> Ap<T, TOut>(IO<Func<T, TOut>> f, IO<T> x)
        {
            return Create(() => f.RunIO()(x.RunIO()));
        }

        public static IO<TOut> Bind<T, TOut>(IO<T> x, Func<T, IO<TOut>> f)
        {
            return Create(() => f(x.RunIO()).RunIO());
        }
        public static IO<T> FromTypeApp<T>(this ITypeApp<IOTypeCon, T> x)
        {
            return (IO<T>)x.UnderlyingObject;
        }

        public static IO<string> Readline()
        {
            return Create(Console.ReadLine);
        }

        public static IO<ValueTuple> WriteLine(string s)
        {
            return Create(() =>
            {
                Console.WriteLine(s);
                return ValueTuple.Create();
            });
        }
    }
}
