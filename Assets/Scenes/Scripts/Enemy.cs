using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour
{
    public List<Transform> points;
    public int nextIdx;
    int idChangeValue = 1;
    [SerializeField] Player player;
    [SerializeField] GameState gameState;

    private void Reset()
    {
        Init();
    }

    void Init()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;

        GameObject root = new GameObject(name + "_root");

        root.transform.position = transform.position;

        transform.SetParent(root.transform);
        GameObject waypoints = new GameObject("Waypoints");
        waypoints.transform.SetParent(root.transform);
        waypoints.transform.position = root.transform.position;

        GameObject p1 = new GameObject("Point 1");
        p1.transform.SetParent(waypoints.transform);
        p1.transform.position = root.transform.position;

        GameObject p2 = new GameObject("Point 2");
        p2.transform.SetParent(waypoints.transform);
        p2.transform.position = root.transform.position;

        points = new List<Transform>();
        points.Add(p1.transform);
        points.Add(p2.transform);
    }

    void Update()
    {
        if (gameState.isStart)
            MoveTo();
    }
    void MoveTo()
    {
        Transform goalPoint = points[nextIdx];

        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, 2*Time.deltaTime);
        
        if(Vector2.Distance(transform.position, goalPoint.position) < 1f)
        {
            if (nextIdx == points.Count - 1)
                idChangeValue = -1;

            if (nextIdx == 0)
                idChangeValue = 1;

            nextIdx += idChangeValue;
        }
    }

    void OnTriggerEnter2D(Collider2D c2d)
    {
        if (c2d.CompareTag("Player"))
        {
            player.TakeDamage(100);
        }

        if (c2d.CompareTag("Bullet"))
        {
            //Destroy coin
            gameState.SetEnemyCount(gameState.enemyCount - 1);
            Destroy(transform.gameObject);
            Debug.Log("Enemy Got Hit");
        }
    }


}
