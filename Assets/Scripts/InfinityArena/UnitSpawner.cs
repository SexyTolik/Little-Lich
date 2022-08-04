using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnitSpawner : MonoBehaviour
{
    public static UnitSpawner instance = null;

    public List<Transform> SpawnPoints = new List<Transform>();
    public List<GameObject> UnitPrefabs = new List<GameObject>();
    public int TotalMobs;
    public int MaxMobs = 10;

    public TextMeshProUGUI points;
    public int score;
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
        StartCoroutine(SpawnMobs());

    }

    private void SpawnNpc()
    {
        if(TotalMobs >= MaxMobs)
        {
            Debug.Log("Сейчас максимальное количество юнитов");
        }
        else
        {
            Instantiate(UnitPrefabs[Random.Range(0, UnitPrefabs.Count)], SpawnPoints[Random.Range(0,SpawnPoints.Count)].position, Quaternion.identity);
        }
       
    }

    public void Update()
    {
        points.text = "Score " + score.ToString();
    }
    IEnumerator SpawnMobs()
    {
        while (true)
        {
            SpawnNpc();
            yield return new WaitForSeconds(1);
        }
       
    }

}
