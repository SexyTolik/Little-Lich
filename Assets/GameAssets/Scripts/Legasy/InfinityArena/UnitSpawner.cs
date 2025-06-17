using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnitSpawner : MonoBehaviour
{
    public static UnitSpawner instance = null;

    //public List<Transform> SpawnPoints = new List<Transform>();
    public List<MobData> Mobs = new List<MobData>();

    public List<BoxCollider2D> SpawnersMobs = new List<BoxCollider2D>();
    private int wave = 0;
    public int Wave { get => wave; }
    private int enemyAlive = 0;
    [SerializeField]
    private float EnemyCountFactor = 0.75f;
    [SerializeField]
    private int WaveStrenght = 0;
    public int EnemyAlive { get => enemyAlive; set
        {
            enemyAlive= value;
            WaveUi.text = "current wave " + Wave + "\n Enemys Alive " + EnemyAlive;
            if(enemyAlive <= 0 && !SpawnInProcces && PlayerValuesStorage.instance != null)
            {
                StartNextWaveButton.SetActive(true);
                ShopGate.ChangeGateState();
            }
        }
    }
    bool SpawnInProcces = false;

    public TextMeshProUGUI WaveUi;
    public GameObject StartNextWaveButton;
    public OpenGate ShopGate;
    public Vector3 PosOnWaveStart;

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
        WaveUi.text = "current wave " + Wave + "\n Enemys Alive " + EnemyAlive;
    }

    public void StartNextWave()
    {
        if (!SpawnInProcces)
        {
            StartNextWaveButton.SetActive(false);
            ShopGate.ChangeGateState();
            GameObject.Find("Player").transform.position = PosOnWaveStart;
            wave++;
            EnemyCountFactor += 0.25f;
            if (wave % 3 == 0)
            {
                WaveStrenght++;
                EnemyCountFactor += 0.15f;
            }
            List<GameObject> currWave = new List<GameObject>();
            foreach (MobData mData in Mobs)
            {
                if (mData._Streanght <= WaveStrenght)
                {
                    currWave.Add(mData._MobPrefab);
                }
            }
            SpawnInProcces = true;
            StartCoroutine(startSpawningMobs(currWave));
        }
    }

    private IEnumerator startSpawningMobs(List<GameObject> mobToSpawn)
    {
        while(enemyAlive <= Mathf.Ceil(4f * EnemyCountFactor) && SpawnInProcces) 
        {
            BoxCollider2D spawnZone = SpawnersMobs[Random.Range(0,SpawnersMobs.Count)];
            Instantiate(mobToSpawn[Random.Range(0, mobToSpawn.Count)], new Vector3(Random.Range(spawnZone.bounds.min.x, spawnZone.bounds.max.x),Random.Range(spawnZone.bounds.min.y, spawnZone.bounds.max.y)), Quaternion.identity);

            EnemyAlive++;
            if(enemyAlive == Mathf.Ceil(4f * EnemyCountFactor))
            {
                SpawnInProcces= false;
            }
            yield return new WaitForSeconds(1.5f);
        }
    }
}
