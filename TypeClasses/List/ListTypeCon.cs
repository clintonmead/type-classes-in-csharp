using System;
using System.Collections.Generic;

namespace TypeClasses.List
{
    public struct ListTypeCon : IFunctorConst<ListTypeCon>, IMonad<ListTypeCon>
    {
        public TypeApp<ListTypeCon, TOut> FMap<TOut, TIn>(Func<TIn, TOut> f, ITypeApp<ListTypeCon, TIn> x)
        {
            List<TIn> inList = x.FromTypeApp();
            int length = inList.Count;
            List<TOut> outList = new List<TOut>(length);
            for (int i = 0; i != length; ++i)
            {
                outList.Add(f(inList[i]));
            }
            return outList.ToTypeApp();
        }

        public TypeApp<ListTypeCon, TOut> FMapConst<TOut, TIn>(TOut c, ITypeApp<ListTypeCon, TIn> x)
        {
            List<TIn> inList = x.FromTypeApp();
            int length = inList.Count;
            List<TOut> outList = new List<TOut>(length);
            for (int i = 0; i != length; ++i)
            {
                outList[i] = c;
            }
            return outList.ToTypeApp();
        }

        public TypeApp<ListTypeCon, TOut> Bind<TIn, TOut>(ITypeApp<ListTypeCon, TIn> x, Func<TIn, TypeApp<ListTypeCon, TOut>> f)
        {
            List<TIn> inList = x.FromTypeApp();
            List<TOut> outList = new List<TOut>();
            foreach (TIn e in inList)
            {
                outList.AddRange(f(e).FromTypeApp());
            }
            return outList.ToTypeApp();
        }

        public TypeApp<ListTypeCon, T> Pure<T>(T x)
        {
            return new List<T>{x}.ToTypeApp();
        }

        public TypeApp<ListTypeCon, TOut> Ap<TIn, TOut>(ITypeApp<ListTypeCon, Func<TIn, TOut>> f, ITypeApp<ListTypeCon, TIn> x)
        {
            List<TIn> inList = x.FromTypeApp();
            List<TOut> outList = new List<TOut>();
            foreach (TIn e in inList)
            {
                outList.AddRange(f.FMap(g => g(e)).FromTypeApp());
            }
            return outList.ToTypeApp();
        }
    }
}
