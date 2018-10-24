using System.Collections.Generic;
using System.Text;

namespace TypeClasses.List
{
    public static class ListUtils
    {
        public static List<T> FromTypeApp<T>(this ITypeApp<ListTypeCon, T> x)
        {
            return (List<T>) x.UnderlyingObject;
        }

        public static TypeApp<ListTypeCon, T> ToTypeApp<T>(this List<T> x)
        {
            return TypeApp.Create(x);
        }

        public static string StringList<T>(this List<T> x)
        {
            StringBuilder s = new StringBuilder();
            s.Append("[");
            bool first = true;
            foreach (T e in x)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    s.Append(", ");
                }

                s.Append(e);
            }
            s.Append("]");
            return s.ToString();
        }
    }
}
