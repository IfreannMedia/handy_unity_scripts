using System;
using System.Collections.Generic;
public class Observable<T> : IObservable<T>
{
    private List<Observer<T>> observers;

    private T _value;
    public T value
    {
        get { return _value; }
        set { _value = value; NotifyObservers(); }
    }

    public Observable(T startingData)
    {
        observers = new List<Observer<T>>();
        value = startingData;
    }

    public IDisposable Subscribe(IObserver<T> observer)
    {
        // Check whether observer is already registered. If not, add it
        if (!observers.Contains(observer as Observer<T>))
        {
            observers.Add(observer as Observer<T>);
            observer.OnNext(_value);
            (observer as Observer<T>).observable = this;
        }
        Unsubscriber<T> unsubber = new Unsubscriber<T>(observers, observer as Observer<T>);
        (observer as Observer<T>).disposable = unsubber;
        return unsubber;
    }

    public void ClearAllObservers()
    {
        foreach (var observer in observers)
            observer.OnCompleted();

        observers.Clear();
    }

    public void NotifyObservers()
    {
        observers.ForEach(obs => {
            if(obs != null)
            {
                obs.OnNext(_value);
            }
        });
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
