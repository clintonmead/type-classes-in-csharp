using System;
using System.Collections.Generic;
using System.Text;

namespace TypeClasses
{
    public interface IIdentity<out T>
    {
        T Value { get; }
    }
}
