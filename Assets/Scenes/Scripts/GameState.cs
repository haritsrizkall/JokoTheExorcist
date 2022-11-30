using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] EnemySpawner enemySpawner;

    public bool isStart = false;
    public int enemyCount = 1;  
    void Start()
    {
        isStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        isStart = true;
    }

    public void SetEnemyCount(int x)
    {
        enemyCount = x;
    }

    void LoadBossScene()
    {
        SceneManager.LoadScene(0);
    }
}
