namespace TypeClasses
{
    public static class StaticCastTo<TOut>
    {
        public static TOut From<T>(T x) where T : TOut
        {
            return x;
        }
    }
}
