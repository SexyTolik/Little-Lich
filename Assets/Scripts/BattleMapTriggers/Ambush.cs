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
    public Collider2D SpawnZone;


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
            int RandNum = Random.Range(1, 100);
            int EnemN = -1;
            foreach(int chans in SpawnWeight)
            {
                EnemN++;
                if(chans >= RandNum)
                {
                    if(SpawnZone != null)
                    {
                        Instantiate(Enemys[EnemN], new Vector3(Random.Range(SpawnZone.bounds.min.x, SpawnZone.bounds.max.x), Random.Range(SpawnZone.bounds.min.y, SpawnZone.bounds.max.y), 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(Enemys[EnemN], SpawnPoints[Random.Range(0, SpawnPoints.Count)].transform.position, Quaternion.identity);
                    }
                    break;
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
