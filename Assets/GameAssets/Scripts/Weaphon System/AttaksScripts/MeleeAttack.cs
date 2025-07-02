using UnityEngine;

[CreateAssetMenu(fileName = "MeleeAttack", menuName = "Attacks/MeleeAttack")]
public class MeleeAttack : AttackBase
{
    public float AttackRange = 1f;
    public int Damage = 10;

    public override void PerformAttack(Transform attaker, Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(attaker.position, direction, AttackRange);
        if (hit.collider != null && hit.collider.CompareTag("Enemy"))
        {
            Debug.Log(attaker.name + " attacked " + hit.collider.name);
        }
    }
}
