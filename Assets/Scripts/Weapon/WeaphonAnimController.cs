using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaphonAnimController : MonoBehaviour
{
    private Animator anim;
    private IDirection dir;
    private StabingWeaphon stabweaphon;
    void Start()
    {
        anim = GetComponent<Animator>();
        dir = gameObject.GetComponentInParent<IDirection>();
        stabweaphon = GetComponent<StabingWeaphon>();
    }

    void Update()
    {
        anim.SetFloat("Horizontal", dir.lastDir.x);
        anim.SetFloat("Vertical", dir.lastDir.y);
        anim.SetBool("IsAttaking", stabweaphon.IsAttacking);
    }

}
