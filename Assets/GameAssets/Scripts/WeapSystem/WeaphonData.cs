using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaphonVariant", menuName = "Weaphon System/WeaphonData")]
public class WeaphonData : ScriptableObject
{
    public string WeaphonName = "SomeName";
    public Sprite WeaphonSprite;
    public Animator WeaphonAnimaror;
    public float Damage;
    public float AttakSpeed;

    public AttakVariantData AttakVariant0, AttakVariant1;

    public List<AbstractPassiveEffect> PassiveEffects;

    public void InitPassives()
    {
        foreach (var passiveEffect in PassiveEffects)
        {
            passiveEffect.InitEffect();
        }
    }

    public void DeletPassives()
    {
        foreach(var passiveEffect in PassiveEffects)
        {
            passiveEffect.DeleteEffect();
        }
    }

}
