using UnityEngine;

public class JumpingState : PlayerState
{
    float jumpForce = 5f;
    bool grounded = true;
    float jumpStart;
    float jumpDelay = 0.2f;

    public override void Enter(Player player)
    {
        Debug.Log("Jumping");
        RaycastHit2D hit1 = Physics2D.Raycast(player.transform.position - new Vector3(.5f, .51f, 0f), player.transform.TransformDirection(Vector2.down), 0.05f);
        RaycastHit2D hit2 = Physics2D.Raycast(player.transform.position - new Vector3(-.5f, .51f, 0f), player.transform.TransformDirection(Vector2.down), 0.05f);
        //Debug.Log("hit = " + hit.collider.name);
        if (hit1 || hit2)
        {
            Debug.Log("Start on ground");
            grounded = false;
            jumpStart = Time.time;
            Rigidbody2D rig = player.GetComponent<Rigidbody2D>();
            rig.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
        }
        else
        {
            Debug.Log("Start in air");
            grounded = false;
        }
    }
    public override PlayerState HandleInput(Player player)
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) && !grounded)
            return new WalkingState();
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            return new WalkingState();
        else if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && grounded)
            return new StandingState();
        return null;
    }

    public override void Update(Player player)
    {
        if (Time.time - jumpStart > jumpDelay)
        {
            RaycastHit2D hit1 = Physics2D.Raycast(player.transform.position - new Vector3(.5f, .51f, 0f), player.transform.TransformDirection(Vector2.down), 0.05f);
            RaycastHit2D hit2 = Physics2D.Raycast(player.transform.position - new Vector3(-.5f, .51f, 0f), player.transform.TransformDirection(Vector2.down), 0.05f);
            //Debug.Log("hit = " + hit.collider.name);
            if (hit1 || hit2)
                grounded = true;
        }
    }
}