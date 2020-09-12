using System;
using System.Collections.Generic;

public class Observable<T> : IObservable<T>
{
    private List<Observer<T>> observers;
    private List<T> values;
    public Observable()
    {
        observers = new List<Observer<T>>();
        values = new List<T>();
    }

    public IDisposable Subscribe(IObserver<T> observer)
    {
        // Check whether observer is already registered. If not, add it
        if (!observers.Contains(observer as Observer<T>))
        {
            observers.Add(observer as Observer<T>);
            // Provide observer with existing data.
            foreach (var item in values)
                observer.OnNext(item);
        }
        return new Unsubscriber<T>(observers, observer as Observer<T>);
    }

    public void ClearAllObservers()
    {
        foreach (var observer in observers)
            observer.OnCompleted();

        observers.Clear();
    }

    public void NotifyObservers()
    {
        foreach (var item in values)
            observers.ForEach(obs => obs.OnNext(item));
    }

    public void Unsubscribe(Observer<T> observer)
    {
        int index = observers.IndexOf(observer);
        if (index > -1)
        {
            observers.Remove(observer);
        }
    }
}
