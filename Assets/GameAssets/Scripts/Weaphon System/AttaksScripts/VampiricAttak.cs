using UnityEngine;
[CreateAssetMenu(fileName = "VampiricAttak", menuName = "Attack/VampiricAttak")]
public class VampiricAttak : AttackBase
{
    public AttackBase BaseAttack;
    public float LifeStealPercent = 20f;

    public override void PerformAttack(Transform attaker, Vector2 direction)
    {
        //TODO сделать проверку на попадание и как то получить урон
        BaseAttack.PerformAttack(attaker, direction);
         //Debug.Log(attaker.name + " heal " + (BaseAttack. LifeStealPercent) + "%");
    }
}
