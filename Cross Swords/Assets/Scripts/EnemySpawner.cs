using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;

    [SerializeField] GameObject enemy;

    private Vector3[] spawnPos;
    private Vector3[] spawnRot;

    float maxSpawnInterval = 5.0f;
    float minSpawnInterval = 2.0f;
    float timer = 0.0f;

    public bool spawnerOn;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnerOn = false;
        spawnPos = new Vector3[] { new Vector3(4.55f, 1, 0), new Vector3(0, 1, -4.5f), new Vector3(-4.5f, 1, 0), new Vector3(0, 1, 4.5f) };
        spawnRot = new Vector3[] { new Vector3(0, 90.0f, 0), new Vector3(0, 180.0f, 0), new Vector3(0, -90.0f, 0), new Vector3(0, 0, 0) };
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnerOn)
        {
            if (timer > maxSpawnInterval)
            {
                SpawnRandom();
                DecreaseTime();
                timer = 0f;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }

    void SpawnRandom()
    {
        int ran = Random.Range(0, spawnPos.Length);
        GameObject enemyClone = Instantiate(enemy);
        enemyClone.transform.position = spawnPos[ran];
        enemyClone.transform.Rotate(spawnRot[ran]);
    }

    void DecreaseTime()
    {
        if(maxSpawnInterval > minSpawnInterval)
        {
            maxSpawnInterval--;
        }
    }
}
