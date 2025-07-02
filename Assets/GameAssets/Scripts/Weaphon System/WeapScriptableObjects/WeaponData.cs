using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapon")]
public class WeaponData : ScriptableObject
{
    public string WeaponName;
    public AttackBase PrimaryAttack;
    public AttackBase SecondaryAttack;
    public IPassiveEffect[] PassiveEffects;
}
