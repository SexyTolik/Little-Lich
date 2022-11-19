using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Ambush : MonoBehaviour
{
    public List<GameObject> Enemys = new List<GameObject>();
    public List<int> SpawnWeight = new List<int>();
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
            int RandNum = Random.Range(1, 100);

           // SpawnWeight.OrderBy()
            yield return new WaitForSeconds(0.1f);
        }
    }
}
