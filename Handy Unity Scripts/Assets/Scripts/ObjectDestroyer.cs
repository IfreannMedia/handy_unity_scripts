using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public void DestroyObject(GameObject obj)
    {
        DestroyObject(obj);
    }

    public void DestroyAfterTime(GameObject obj, float time)
    {
        StartCoroutine(DestroyAfter(obj, time));
    }

    private IEnumerator DestroyAfter(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        DestroyObject(obj);
        yield return null;
    }
}
