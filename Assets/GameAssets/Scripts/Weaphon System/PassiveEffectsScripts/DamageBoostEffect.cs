using UnityEngine;
[CreateAssetMenu(fileName = "DamageBoostEffect", menuName = "Effects/DamageBoostEffect")]
public class DamageBoostEffect : ScriptableObject, IPassiveEffect
{
    public float BoostAmount = 1.5f;
    //TODO Реализовать увеличение урона
    public void ApplyEffect(PassiveEffectsManager manager)
    {

    }

    public void RemoveEffect(PassiveEffectsManager manager)
    {
        
    }
}
