using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public float Radius = 1;
    public float frequency;
    public int limit;
    float lastSpawnedTime;
    private bool isBossSpawn = false;
    [SerializeField] GameState gameState;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject boss;

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.B)) SpawnObject();
        if((Time.time > lastSpawnedTime + frequency) && limit > 0 && gameState.isStart)
        {
            Debug.Log("SPAWSNN");
            gameState.SetEnemyCount(gameState.enemyCount + 1);
            limit--;
            SpawnObject();
            lastSpawnedTime = Time.time;
        }

        if (gameState.isStart && limit == 0 && gameState.enemyCount == -1 && !isBossSpawn)
        {
            SpawnBoss();
            Debug.Log("SPAWN BOS");
            isBossSpawn = true;
        }
    }

    void SpawnObject()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y);
        Instantiate(enemy, pos, Quaternion.identity);

    }

    void SpawnBoss()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y);
        Instantiate(boss, pos, Quaternion.identity);

    }

    public void SetFrequency(int freq)
    {
        frequency = freq;
    }

    public void SetLimit(int lim)
    {
        limit = lim;
    }

}
