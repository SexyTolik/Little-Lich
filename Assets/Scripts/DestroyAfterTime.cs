using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float TimeUntilDestroy = 1f;
    void Start()
    {
        StartCoroutine(DestroyAfter());
    }
    
    IEnumerator DestroyAfter()
    {
        yield return new WaitForSeconds(TimeUntilDestroy);
        Destroy(gameObject);
    }
}
