using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameState gameState;
    [SerializeField] Player player;
    void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D c2d)
    {
        //Destroy the coin if Object tagged Player comes in contact with it
        if (c2d.CompareTag("Player"))
        {
            //Destroy coin
            player.SetJumpBaseAbility(2);
            Destroy(gameObject);
        }
    }
}
