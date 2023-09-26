using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public string collectibleType;
    public Player player;
    public GameObject image;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>(); 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collectibleType == "Key")
                player.CollectItem(image);
            else if (collectibleType == "secret")
                player.CollectItem(image);
            gameObject.SetActive(false);
        }
    }
}