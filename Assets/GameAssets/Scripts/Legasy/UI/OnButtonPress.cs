using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnButtonPress : MonoBehaviour, IPointerDownHandler, IPointerUpHandler//,IPointerEnterHandler
{ 

    public GameObject Radius;
    public NpcSpawnSpell spell;

    public void OnPointerDown(PointerEventData eventData)
    {
        Radius.SetActive(true);
        spell.DetectCorpces();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Radius.SetActive(false);
    }

    /*public void OnPointerEnter(PointerEventData eventData)
    {
        Radius.enabled = true;
    }*/

}
