using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public GameObject winScreen;
    public SecretChecker secretChecker;

    void OnTriggerEnter2D()
    {
        winScreen.SetActive(true);
        secretChecker.CheckSecret();
        Invoke("NextScene", 2f);
    }

    void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
