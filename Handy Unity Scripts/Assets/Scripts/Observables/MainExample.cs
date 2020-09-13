using UnityEngine;

public class MainExample : MonoBehaviour
{

    private Observable<int> healthPoints = new Observable<int>(100);
    private Observer<int> intObserver = new Observer<int>();
    
    void Start()
    {
        healthPoints.Subscribe(intObserver);
        intObserver.Next += eventHandlerMethod;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            healthPoints.value -= 10;
        }
    }

    private void eventHandlerMethod(object sender, GenericEventArgs<int> e)
    {
        print("recieved health points: " + e.data);
        // TODO healthPoints.Unsubscribe(intObserver); ERROR: InvalidOperationException: Collection was modified; enumeration operation may not execute.
    }
}
