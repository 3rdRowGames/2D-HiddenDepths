using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : Fish
{
    public Transform player;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Vector2 movement;

    public override void Update()
    {

        if (player != null)
        {
            SharkLogic();
            base.Update();
        }
    }

    private void FixedUpdate()
    {
        MoveCharacter(movement);
    }

    public void SharkLogic()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        rb.rotation = angle;
        direction.Normalize();
        movement = direction;

        //Clamp Sharks Position to a Fixed Playable Area
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -16f, 16f), Mathf.Clamp(transform.position.y, -8f, 5f), transform.position.z);
    }

    private void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
