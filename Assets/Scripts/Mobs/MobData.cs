using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "MobData", menuName = "Mobs/MobDataFile")]
public class MobData : ScriptableObject
{
    public RuntimeAnimatorController _AnimController;
    public Sprite SpellButton1, SpellButton2;
    public GameObject _MobPrefab;
    public float _MaxHealth;
    public float _Speed;
    public float _VisionRange;
    public float _AttakRange;
    public float _AttakDamage;
    public float _AttakDelay;
    public float _CastDelay;
    public float _CastCost;
    public string _Description;
    public string _MobName;
    [SerializeField]
    private int _mobLevel = 0;
    public int _MobLevel
    {
        get => _mobLevel;
        set => _mobLevel = Mathf.Clamp(value, 0, 3);
    }
}
