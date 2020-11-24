using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Fix the count of GameObjects
public class SpawnManager : MonoBehaviour
{
    [Header("GameObject Manager")]
    public GameObject targetPrefab;
    public GameObject enemyPrefab;

    [Header("Properties")]
    public int targetCount;
    public int enemyCount;
    public int waveNumber = 1;

    private float spawnRangeX = 1750;
    private float spawnRangeY = 1750;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        SpawnObstacle(waveNumber);
        SpawnEnemy(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        Count();

        gameManager.UpdateTargets(targetCount);
        gameManager.UpdateEnemies(enemyCount);

        if (targetCount == 0)
        {
            waveNumber++;
            SpawnObstacle(waveNumber);
            SpawnEnemy(waveNumber);
            gameManager.UpdateWave(1);
        }
    }

    void Count()
    {
        CountTarget();
        CountEnemy();
    }

    void CountTarget()
    {
        targetCount = GameObject.FindGameObjectsWithTag("Target").Length;
    }

    void CountEnemy()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    void SpawnObstacle(int obstaclesToSpawn)
    {
        for(int i = 0; i < obstaclesToSpawn; i++)
        {
            Instantiate(targetPrefab, GenerateSpawnPosition(), targetPrefab.transform.rotation);
        }
    }

    void SpawnEnemy(int numEnemies)
    {
        for(int i = 0; i < numEnemies; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        // Floats that generate a random number within a range
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnPosY = Random.Range(-spawnRangeY, spawnRangeY);
        float spawnPosZ = Random.Range(525, 2275);
        // Creates a coordinate with the random floats set
        Vector3 randomPos = new Vector3(spawnPosX,spawnPosY, spawnPosZ);
        // Returns the result of the randomPos coordinate
        return randomPos;
    }
}
