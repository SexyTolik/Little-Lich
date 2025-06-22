using log4net.Util;
using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public abstract class BaseAttak
{
    public abstract bool MakeAttak(Vector2 attakPoint, float damage, float attakRadius, string EnemyTag);

    protected Collider2D NearestEnemy(Vector2 point,float attakRadius, string tag)
    {
        // Получаем все коллайдеры в радиусе attackRange
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(point, attakRadius);
        Collider2D closestEnemy = null;
        float minDistance = float.MaxValue;

        foreach (var collider in hitColliders)
        {
            // Проверяем, что объект имеет тег "Enemy"
            if (collider.gameObject.CompareTag(tag))
            {
                float distance = Vector2.Distance(point, collider.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestEnemy = collider;
                }
            }
        }

        return closestEnemy; // Возвращает null, если врагов в зоне нет
    }

    protected Collider2D[] NearestEnemys(Vector2 point, float attakRadius, string tag)
    {
        // Получаем все коллайдеры в радиусе attackRange
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(point, attakRadius);
        List<Collider2D> Enemys = null;

        foreach (var collider in hitColliders)
        {
            // Проверяем, что объект имеет тег "Enemy"
            if (collider.gameObject.CompareTag(tag))
            {
               Enemys.Add(collider);
            }
        }

        return Enemys.ToArray(); // Возвращает null, если врагов в зоне нет
    }
}
