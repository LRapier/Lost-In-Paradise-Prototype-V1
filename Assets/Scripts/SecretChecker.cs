using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SecretChecker : MonoBehaviour
{
    public Player player;
    bool confirmSecret = false;
    public SecretMenu secretMenu;

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void CheckSecret()
    {
        for (int x = 0; x < 3; x++)
        {
            if (player.inventorySprites[x].sprite != null)
            {
                if (player.inventorySprites[x].sprite.name == "Secret")
                    confirmSecret = true;
            }
        }
    }

    public void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 2 && SceneManager.GetActiveScene().buildIndex != 3)
        {
            Destroy(this.gameObject);
        }
        else if(SceneManager.GetActiveScene().buildIndex == 3)
        {
            if(confirmSecret)
            {
                secretMenu = FindAnyObjectByType<SecretMenu>();
                secretMenu.image.color = Color.white;
            }
        }
    }
}
