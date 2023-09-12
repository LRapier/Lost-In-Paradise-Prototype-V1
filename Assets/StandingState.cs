using UnityEngine;
public class StandingState : PlayerState
{
    public override void Enter(Player player)
    {
        Debug.Log("Standing");
        float x = Input.GetAxis("Horizontal");
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(x * 1.5f, 0f);
        player.transform.localScale = new Vector3(1f, 1f, 1f);
    }
    public override PlayerState HandleInput(Player player)
    {
        if (Input.GetKeyDown(KeyCode.Space))
            return new JumpingState();
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            return new WalkingState();
        return null;
    }
}