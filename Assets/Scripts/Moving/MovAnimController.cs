using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovAnimController : MonoBehaviour
{
    private Animator anim;
    private IDirection moveDir;
    void Start()
    {
        anim = GetComponent<Animator>();
        moveDir = GetComponent<IDirection>();
    }

    void Update()
    {
        anim.SetFloat("Horizontal", moveDir.lastDir.x);
        anim.SetFloat("Vertical", moveDir.lastDir.y);
        anim.SetBool("IsMoving", moveDir.IsMoving);
    }
}
