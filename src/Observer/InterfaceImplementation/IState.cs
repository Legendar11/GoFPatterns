namespace Observer.InterfaceImplementation;

internal interface IState<T>
{
    T State { get; }
}
