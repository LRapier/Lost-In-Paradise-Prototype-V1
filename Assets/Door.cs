using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Player player;
    public GameObject winScreen;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void OnTriggerEnter2D()
    {
        Debug.Log("Triggered");
        if (player.hasKey)
        {
            winScreen.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
