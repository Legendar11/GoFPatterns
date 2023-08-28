namespace Memento;

internal interface ICaretaker
{
    void AddMemento(IMemento memento);

    IMemento PopMemento();
}
