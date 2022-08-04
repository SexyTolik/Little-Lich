using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Pathfinding;

public class MobController : MonoBehaviour
{
    [Header("Поля устанавливаемые в едиторе")]

    public GameObject Pointer;
    public MobData CurMob;

    [Header("Свойства берущиеся из Data файла")]
    public RuntimeAnimatorController AnimController;
    public float MaxHealth;
    public float Speed;
    public float VisionRange;
    public float AttakRange;
    public float AttakDamage;
    public float AttakDelay;

    [Header("Поля устанавливаемые в рантайме")]
    public AIDestinationSetter Setter;
    public AIPath Aipath;
    public Iweapon currWeaphon;
    public CircleCollider2D MovePatrolZone;
    public GameObject Target;
    public float RandomMoveChangePointTime = 3f;
    public bool Enemy;



    private BaseMobState currState;
    private Dictionary<Type, BaseMobState> stateMap;

    public delegate void MethodWithDelay();
    public MethodWithDelay DelayMethod;
    public MethodWithDelay AttackDelayMethod;

    private void initializeStateMap()
    {
       stateMap = new Dictionary<Type, BaseMobState>();
        stateMap[typeof(MobRandomMoveState)] = new MobRandomMoveState(Setter,MovePatrolZone,Pointer,this, Aipath);
        stateMap[typeof(MobMoveToTargetState)] = new MobMoveToTargetState(Target, Setter, this);
        stateMap[typeof(MobAttackState)] = new MobAttackState(this);

    }
    private BaseMobState getState<T>() where T : BaseMobState
    {
        var type = typeof(T);
        return (T)stateMap[type];
    }

    private void Awake()
    {
        LoadMob(CurMob);
        GetComponent<HeathBeh>().MaxHealth = MaxHealth;
        GetComponent<AIPath>().maxSpeed = Speed;
        Setter = GetComponent<AIDestinationSetter>();
        Aipath = GetComponent<AIPath>();
        currWeaphon = GetComponentInChildren<Iweapon>();
        currWeaphon.Dmg = AttakDamage;
        currWeaphon.AttackDelay = AttakDelay;        
        if (gameObject.CompareTag("Enemy"))
        {
            Enemy = true;
            MovePatrolZone = GetComponentInChildren<CircleCollider2D>();
        }
        else
        {
            Enemy = false;
            MovePatrolZone = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<CircleCollider2D>();
        }

        initializeStateMap();
        InitializeState<MobRandomMoveState>();

    }
    public void ChangeCurrState<T>() where T : BaseMobState
    {
        currState.Exit();
        currState = getState<T>();
        currState.Entry();
    }
    public void InitializeState<T>() where T : BaseMobState
    {
        currState = getState<T>();
        currState.Entry();
    }
    private void Update()
    {
        currState.UpdateLogic();
       // Debug.Log("Текущий стейт -> " + currState);

    }

    public IEnumerator Timer(float delay, MethodWithDelay mwd)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            mwd();
        }
    }

    public void LoadMob(MobData data)
    {
        AnimController = data._AnimController;
        MaxHealth = data._MaxHealth;
        Speed = data._Speed;
        VisionRange = data._VisionRange;
        AttakRange = data._AttakRange;
        AttakDamage = data._AttakDamage;
        AttakDelay = data._AttakDelay;
    }

    private void OnDestroy()
    {
        Destroy(Pointer);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!Enemy && collision.gameObject.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
        }
    }
}
