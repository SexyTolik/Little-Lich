using UnityEngine;
[CreateAssetMenu(fileName = "DamageBoostEffect", menuName = "Effects/DamageBoostEffect")]
public class DamageBoostEffect : PassiveEffectBase
{
    public float BoostAmount = 1.5f;
    //TODO Реализовать увеличение урона
    public override void ApplyEffect(PassiveEffectsManager manager)
    {
        
    }

    public override void RemoveEffect(PassiveEffectsManager manager)
    {
        
    }
}
