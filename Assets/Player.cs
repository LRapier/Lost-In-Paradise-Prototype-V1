using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private PlayerState standState = new StandingState();
    public bool hasKey = false;
    public Image[] inventorySprites;

    private void Start()
    {
        standState.Enter(this);
    }

    private void Update()
    {
        PlayerState state = standState.HandleInput(this);
        if (state != null)
        {
            standState.Exit(this);
            standState = state;
            standState.Enter(this);
        }
        standState.Update(this);
    }

    public void CollectItem(Sprite image)
    {
        hasKey = true; //temp
        for (int x = 0; x < 3; x++)
        {
            if (x == 0)
                Debug.Log(inventorySprites[x].sprite);
            if (inventorySprites[x].sprite == null)
                inventorySprites[x].sprite = image;
            if (x == 0)
                Debug.Log(inventorySprites[x].sprite);
        }
    }
}