using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MobData", menuName = "Mobs/MobDataFile")]
public class MobData : ScriptableObject
{
    public RuntimeAnimatorController _AnimController;
    public float _MaxHealth;
    public float _Speed;
    public float _VisionRange;
    public float _AttakRange;
    public float _AttakDamage;
    public float _AttakDelay;
}
