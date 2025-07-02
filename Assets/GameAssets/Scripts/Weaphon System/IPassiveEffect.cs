using UnityEngine;

public interface IPassiveEffect
{
    void ApplyEffect(PassiveEffectsManager unit);
    void RemoveEffect(PassiveEffectsManager unit);
}
