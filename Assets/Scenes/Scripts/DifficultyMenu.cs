using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] string difficulty;
    [SerializeField] GameState gameState;
    [SerializeField] EnemySpawner enemySpawner;
    [SerializeField] Boss boss;
    public void SetEasy()
    {
        difficulty = "Easy";
        enemySpawner.SetFrequency(6);
        enemySpawner.SetLimit(1);
        gameState.StartGame();
        boss.SetHP(200);
        Destroy(gameObject);
    }
    public void SetMedium()
    {
        difficulty = "Medium";
        enemySpawner.SetFrequency(4);
        enemySpawner.SetLimit(2);
        gameState.StartGame();
        boss.SetHP(300);
        Destroy(gameObject);
    }
    public void SetHard()
    {
        difficulty = "Hard";
        enemySpawner.SetFrequency(2);
        enemySpawner.SetLimit(3);
        gameState.StartGame();
        boss.SetHP(400);
        Destroy(gameObject);
    }
}
