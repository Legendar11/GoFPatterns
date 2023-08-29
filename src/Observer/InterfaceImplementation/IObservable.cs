namespace Observer.InterfaceImplementation;

internal interface IObservable
{
    void AttachObserver(IObserver observer);

    void DetachObserver(IObserver observer);

    // Should be called only inside an implemented class
    void Notify();
}
