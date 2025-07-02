using UnityEngine;

public abstract class AttackBase : ScriptableObject
{
    public string AttackName;
    public float cooldown;
    public abstract void PerformAttack(Transform attaker, Vector2 direction);
}