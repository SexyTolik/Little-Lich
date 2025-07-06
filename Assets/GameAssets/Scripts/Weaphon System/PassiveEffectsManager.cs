using UnityEngine;
using System.Collections.Generic;

public class PassiveEffectsManager : MonoBehaviour
{
    private List<PassiveEffectBase> activeEffects = new List<PassiveEffectBase>();

    public void EquipWeapon(WeaponData weapon)
    {
        foreach (var effect in weapon.PassiveEffects)
        {
            effect.ApplyEffect(this);
            activeEffects.Add(effect);
        }
    }

    public void UnequipWeapon(WeaponData weapon)
    {
        foreach (var effect in weapon.PassiveEffects)
        {
            effect.RemoveEffect(this);
            activeEffects.Remove(effect);
        }
    }
}
