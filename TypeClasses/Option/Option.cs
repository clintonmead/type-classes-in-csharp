using System;

namespace TypeClasses
{

    public struct Option<T> : ITypeApp<OptionTypeCon, T>, IOption<T>
    {
        private readonly T _value;
        private readonly bool _hasValue;

        public Option(T value)
        {
            _value = value;
            _hasValue = true;
        }
        public bool HasValue
        {
            get { return _hasValue; }
        }

        public T Value
        {
            get { return _value; }
        }

        public static readonly Option<T> None = new Option<T>();

        public static implicit operator Option<T>(None x)
        {
            return None;
        }

        public static implicit operator Option<T>(T x)
        {
            return Option.Create(x);
        }

        public static implicit operator Option<T>(TypeApp<OptionTypeCon, T> x)
        {
            return x.FromTypeApp();
        }

        public static implicit operator TypeApp<OptionTypeCon, T>(Option<T> x)
        {
            return TypeApp.Create(x);
        }

        public object UnderlyingObject
        {
            get { return this; }
        }

        public override string ToString()
        {
            return this.Match(x => x.ToString(), "None");
        }
    }

    public static class Option
    {
        public static Option<T> Create<T>(T value)
        {
            return new Option<T>(value);
        }

        public static readonly None None = new None();
        public static Option<TOut> FMap<TIn, TOut>(Func<TIn, TOut> f, IOption<TIn> option)
        {
            return option.Match(x => Create(f(x)), None);
        }

        public static Option<TOut> Bind<TIn, TOut>(Option<TIn> option, Func<TIn, Option<TOut>> f)
        {
            return option.Match(f, None);
        }

        public static Option<TOut> Ap<TIn, TOut>(IOption<Func<TIn, TOut>> f, IOption<TIn> x)
        {
            return f.Match(fValue => FMap(fValue, x), None);
        }

        public static TB Foldr<TA, TB>(Func<TA, TB, TB> f, TB z, Option<TA> x)
        {
            return x.HasValue ? f(x.Value, z) : z;
        }

        public static Option<T> FromTypeApp<T>(this ITypeApp<OptionTypeCon, T> x)
        {
            return (Option<T>) x.UnderlyingObject;
        }

        public static TOut Match<TIn, TOut>(this IOption<TIn> x, Func<TIn, TOut> f, Func<TOut> g)
        {
            return x.HasValue ? f(x.Value) : g();
        }
        public static TOut Match<TIn, TOut>(this IOption<TIn> x, Func<TIn, TOut> f, TOut c)
        {
            return x.Match(f, () => c);
        }
    }

    public struct None { }
}
