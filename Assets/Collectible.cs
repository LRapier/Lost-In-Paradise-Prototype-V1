using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public string collectibleType;
    public Player player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>(); 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(collectibleType == "Key")
                player.hasKey = true;
            gameObject.SetActive(false);
        }
    }
}