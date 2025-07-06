using UnityEngine;

public abstract class PassiveEffectBase : ScriptableObject
{
    public abstract void ApplyEffect(PassiveEffectsManager unit);
    public abstract void RemoveEffect(PassiveEffectsManager unit);
}
