using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : Fish
{
    public Transform player;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Vector2 movement;

    public bool isStunned;

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
        if(!isStunned)
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ink")
        {
            speed = 1;
            moveSpeed = 1;
            isStunned = true;
        }

        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("isAttacking", true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("isAttacking", false);
        }

        if (collision.gameObject.tag == "Ink")
        {
            isStunned = false;
            /*            moveSpeed = 10;
                        speed = 10;*/
            Debug.Log("SpeedValue from Shark Script " + speed);
        }
    }
}
