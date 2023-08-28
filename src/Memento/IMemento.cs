namespace Memento;

internal interface IMemento<T>
{
    T State { get; set; }
}
