using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalFinish : MonoBehaviour
{
    public Player player;
    public GameObject winScreen;
    public SecretChecker secretChecker;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        secretChecker = GameObject.Find("SecretChecker").GetComponent<SecretChecker>();
    }

    void OnTriggerEnter2D()
    {
        if (player.hasKey)
        {
            winScreen.SetActive(true);
            secretChecker.CheckSecret();
            Invoke("NextScene", 2f);
        }
    }

    void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
