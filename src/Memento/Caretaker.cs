namespace Memento;

internal class Caretaker : ICaretaker
{
    private readonly Stack<IMemento> _history = new();

    public void AddMemento(IMemento memento) => _history.Push(memento);

    public IMemento PopMemento() => _history.Pop();
}
