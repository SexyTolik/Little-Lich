using UnityEngine;

[CreateAssetMenu(fileName = "MobData", menuName = "Mobs/MobDataFile")]
public class MobData : ScriptableObject
{
    public RuntimeAnimatorController _AnimController;
    public Sprite SpellButton1, SpellButton2, GraveBought, GraveUnbought;
    public Sprite TokenImage;
    public GameObject _MobPrefab;
    public float _MaxHealth;
    public float _Speed;
    public float _VisionRange;
    public float _AttakRange;
    public float _AttakDamage;
    public float _AttakDelay;
    public float _CastDelay;
    public float _CastCost;
    public int _Streanght;
    public int _CorpceCost;
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
