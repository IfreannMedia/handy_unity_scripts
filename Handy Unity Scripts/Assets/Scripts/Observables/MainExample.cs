using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainExample : MonoBehaviour
{

    private Observable<int> healthPoints;
    // Start is called before the first frame update
    void Start()
    {
        healthPoints.Subscribe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
