using System;
using System.Collections.Generic;
public class Observer<T> : IObserver<T>
{
    List<T> infos = new List<T>();
    private IDisposable disposable;
    private Observable<T> observable;
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

    public virtual void OnNext(T info)
    {
        
    }
}
