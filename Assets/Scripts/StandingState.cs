using UnityEngine;
public class StandingState : PlayerState
{
    public override void Enter(Player player)
    {
        Debug.Log("Standing");
        float x = Input.GetAxis("Horizontal");
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(x * 1.5f, 0f);
        if(player.transform.localScale.y == 0.5f)
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + .2575f, player.transform.position.z);
        player.transform.localScale = new Vector3(1f, 1f, 1f);
    }
    public override PlayerState HandleInput(Player player)
    {
        if (Input.GetKeyDown(KeyCode.Space))
            return new JumpingState();
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            return new WalkingState();
        else if (Input.GetKeyDown(KeyCode.S))
            return new DuckingState();
        return null;
    }
}