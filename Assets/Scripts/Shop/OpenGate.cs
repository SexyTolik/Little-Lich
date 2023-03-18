using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
    public BoxCollider2D col;
    public Animator animator;

    public void ChangeGateState()
    {
        col.enabled = !col.enabled;
        animator.SetTrigger("Lever");
    }
}
