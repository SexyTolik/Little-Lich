using UnityEngine;

public abstract class AttackBase : ScriptableObject
{
    public string AttackName;
    public float Cooldown;
    public abstract void PerformAttack(Transform attaker, Vector2 direction);
}