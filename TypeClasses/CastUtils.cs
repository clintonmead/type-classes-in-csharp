using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Proxies;
using System.Text;

namespace TypeClasses
{
    public static class CastUtils
    {
        public static Option<T> DynamicCast<T>(this object x)
        {
            T result = (T) x;
            if (result != null)
            {
                return result;
            }
            else
            {
                return Option.None;
            }
        }

        public static Option<TOut> DynamicCastMatch<TOut, TIn, TCast>(
            this TIn x, 
            Func<TCast, TOut> castSuccessFunc,
            Func<TIn, TOut> castFailedFunc)
        {
            return x.DynamicCast<TCast>().Match(castSuccessFunc, () => castFailedFunc(x));
        }

        public static void IsType<T>(this T x)
        {
        }

    }
}
