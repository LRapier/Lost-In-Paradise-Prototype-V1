using UnityEngine;

public class DuckingState : PlayerState
{
    public override void Enter(Player player)
    {
        Debug.Log("Ducking");
        Transform tr = player.GetComponent<Transform>();
        tr.localScale = new Vector3(1f, 0.5f, 1f);
        tr.position = new Vector3(tr.position.x, tr.position.y - .2575f, tr.position.z);
    }
    public override PlayerState HandleInput(Player player)
    {
        if (Input.GetKeyUp(KeyCode.S))
            return new StandingState();
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            return new CrawlingState();
        return null;
    }
}