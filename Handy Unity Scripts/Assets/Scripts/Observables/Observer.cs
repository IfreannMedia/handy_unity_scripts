using System;
// GenericEventArgs => container for event data
public class GenericEventArgs<T> : EventArgs
{
    public T data { get; set; }
}

public class Observer<T> : IObserver<T>
{

    public IDisposable disposable; // for unsubbing
    public Observable<T> observable; // the observable
    private GenericEventArgs<T> argsValueContianer = new GenericEventArgs<T>(); // container for data to be passed

    public Observer()
    {
    }

    // push self into list of observers in observable, ans store IDisposable in private variable
    public virtual void Subscribe(Observable<T> obs)
    {
        observable = obs;
        disposable = obs.Subscribe(this);
    }

    // remove self from observable llist, and call dispose on the IDisposable
    public virtual void Unsubscribe()
    {
        observable.Unsubscribe(this);
        disposable.Dispose();
    }

    public virtual void OnCompleted()
    {
        disposable.Dispose();
    }


    public virtual void OnError(Exception e)
    {

    }

    public event EventHandler<GenericEventArgs<T>> Next; // envent handler for emission of data

    public virtual void OnNext(T info)
    {
        argsValueContianer.data = info;
        Next?.Invoke(this, argsValueContianer);
    }
}
