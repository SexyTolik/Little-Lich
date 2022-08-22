using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambush : MonoBehaviour
{
    public List<GameObject> Enemys = new List<GameObject>();
    public List<Transform> SpawnPoints = new List<Transform>();
    public int EnemysCount = 4;

    private bool isActive = true;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isActive)
        {
            StartCoroutine(spawnAmbush());
            isActive = false;
        }
    }

    private IEnumerator spawnAmbush()
    {
        for (int i = 0; i < EnemysCount; i++)
        {
            Transform TempTransform = SpawnPoints[Random.Range(0, SpawnPoints.Capacity)];
            GameObject Enemy = Instantiate(Enemys[Random.Range(0, Enemys.Capacity)], TempTransform.position,Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
