using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private PlayerState standState = new StandingState();
    public bool hasKey = false;
    public Image[] inventorySprites;
    public TextMeshProUGUI pickupMessage;

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

    public void CollectItem(GameObject pickup)
    {
        SpriteRenderer image = pickup.GetComponent<SpriteRenderer>();
        Collectible collectible = pickup.GetComponent<Collectible>();
        Debug.Log(image.sprite.name);
        for (int x = 0; x < 3; x++)
        {
            Debug.Log(inventorySprites[x].sprite);
            if (inventorySprites[x].sprite == null)
            {
                inventorySprites[x].color = Color.white;
                if (collectible.collectibleType == "Key")
                    hasKey = true;
                inventorySprites[x].sprite = image.sprite;
                pickupMessage.text = "Picked up " + collectible.collectibleType;
                Invoke("ClearMessage", 1f);
                break;
            }
        }
    }

    public void ClearMessage()
    {
        pickupMessage.text = "";
    }
}