using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (player.hasKey)
        {
            winScreen.SetActive(true);
            gameObject.SetActive(false);
            Invoke("NextLevel", 1.5f);
        }
    }

    void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
