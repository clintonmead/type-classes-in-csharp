using System;
using System.Collections.Generic;
using System.Threading;
using TypeClasses;
using TypeClasses.List;

namespace TestTypeClasses
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Add options
            Option<int> x1 = 3;
            Option<int> y1 = 7;

            Option<int> z1 = SeqTwo(x1, y1);

            Console.WriteLine(z1);

            // Add options with "None"
            Option<int> x2 = 3;
            Option<int> y2 = Option.None;

            Option<int> z2 = SeqTwo(x2, y2);

            Console.WriteLine(z2);

            // Lists
            List<int> xList = new List<int> { 1, 2, 3 };
            List<int> yList = new List<int> { 4, 5, 6 };

            List<int> zList = SeqTwo(xList.ToTypeApp(), yList.ToTypeApp()).FromTypeApp();

            Console.WriteLine(zList.StringList());

            // IO
            IO<string> string1Action = IO.Readline();
            IO<string> string2Action = IO.Readline();

            IO<int> num1IOAction = string1Action.FMap(int.Parse);
            IO<int> num2IOAction = string2Action.FMap(int.Parse);

            IO<int> numResultIOAction = SeqTwo(num1IOAction, num2IOAction);

            int numResult = numResultIOAction.RunIO();
            Console.WriteLine(numResult);

            Console.WriteLine("Done");

            Thread.Sleep(-1);
        }

        public static TypeApp<TMonad, int> SeqTwo<TMonad>(
            ITypeApp<TMonad, int> first,
            ITypeApp<TMonad, int> second)
            where TMonad : IMonad<TMonad>, new()
        {
            return
                from x in first
                from y in second
                //from z in Applicative<TMonad>.Pure(2)
                let z = 2
                select x * y * z;
        }
    }
}
