using System;
using System.Collections.Generic;

public class Unsubscriber<T> : IDisposable
{
    private List<Observer<T>> _observers;
    private Observer<T> _observer;
    internal Unsubscriber(List<Observer<T>> observers, Observer<T> observer)
    {
        _observers = observers;
        _observer = observer;
    }



    public void Dispose()
    {
        if (_observers.Contains(_observer))
            _observers.Remove(_observer);
    }
}
