using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    private void Start()
    {
        offset= transform.position;
    }
    void Update()
    {
        if (player != null)
        {
            this.transform.position = new Vector3(player.position.x, player.position.y, this.transform.position.z);
        }
    }
}
