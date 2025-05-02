using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGlobalMapController : MonoBehaviour
{
    
    void Update()
    {
#if !UNITY_EDITOR && UNITY_ANDROID

        if(Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                CheckTouch(Input.GetTouch(0).position);
            }
        }
#else
        if (Input.GetMouseButtonDown(0))
        {
            CheckTouch(Input.mousePosition);
        }
#endif
    }

    private void CheckTouch(Vector3 pos)
    {
        Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
        Vector2 touchPos = new Vector2(wp.x, wp.y);

        Collider2D hit = Physics2D.OverlapPoint(touchPos);

        if(hit && hit.CompareTag("Location"))
        {
            hit.GetComponent<LocationController>().GoInLocation();
        }
    }
}
