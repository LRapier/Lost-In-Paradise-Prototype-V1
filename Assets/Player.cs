using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerState standState = new StandingState();
    public bool hasKey = false;

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
}