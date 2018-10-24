namespace TypeClasses
{
    public interface IOption<out T>
    {
        bool HasValue { get; }
        T Value { get; }
    }
}
