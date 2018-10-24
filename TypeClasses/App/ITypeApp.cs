namespace TypeClasses
{
    public interface ITypeApp<out TConstructor, out TType> : ITypeApp
    {
    }

    public interface ITypeApp
    {
        object UnderlyingObject { get; }
    }

}
