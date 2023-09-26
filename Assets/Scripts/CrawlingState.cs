using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlingState : PlayerState
{
    float moveSpeed = 3f;
    bool grounded = true;
    bool initialGrounded = true;

    public override void Enter(Player player)
    {
        Debug.Log("Crawling");
        Rigidbody2D rig = player.GetComponent<Rigidbody2D>();
        Move(rig);
        Transform tr = player.GetComponent<Transform>();
        tr.localScale = new Vector3(1f, 0.5f, 1f);
        tr.position = new Vector3(tr.position.x, tr.position.y - .2575f, tr.position.z);
        RaycastHit2D hit1 = Physics2D.Raycast(player.transform.position - new Vector3(.5f, .51f, 0f), player.transform.TransformDirection(Vector2.down), 0.05f);
        RaycastHit2D hit2 = Physics2D.Raycast(player.transform.position - new Vector3(-.5f, .51f, 0f), player.transform.TransformDirection(Vector2.down), 0.05f);
        //Debug.Log("hit = " + hit.collider.name);
        if (!hit1 && !hit2)
        {
            grounded = false;
            initialGrounded = false;
        }
    }
    public override PlayerState HandleInput(Player player)
    {
        if (Input.GetKeyUp(KeyCode.S))
            return new WalkingState();
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && grounded)
            return new DuckingState();
        if (Input.GetKeyDown(KeyCode.Space))
            return new JumpingState();
        return null;
    }

    public override void Update(Player player)
    {
        Rigidbody2D rig = player.GetComponent<Rigidbody2D>();
        Move(rig);
        RaycastHit2D hit1 = Physics2D.Raycast(player.transform.position - new Vector3(.5f, .51f, 0f), player.transform.TransformDirection(Vector2.down), 0.05f);
        RaycastHit2D hit2 = Physics2D.Raycast(player.transform.position - new Vector3(-.5f, .51f, 0f), player.transform.TransformDirection(Vector2.down), 0.05f);
        //Debug.Log("hit = " + hit.collider.name);
        if (!hit1 && !hit2)
        {
            grounded = false;
            if (!initialGrounded || !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
                moveSpeed = 1.5f;
        }
        else
        {
            grounded = true;
            moveSpeed = 3f;
        }
    }

    void Move(Rigidbody2D rig)
    {
        float x = Input.GetAxis("Horizontal");
        float y = rig.velocity.y;

        rig.velocity = new Vector2(x * moveSpeed, y);
    }
}
