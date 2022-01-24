using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : Fish
{
    public GameObject siren;
    MouseFollow mouseFollow;
    public Animator anim;

    // Start is called before the first frame update
    new void Start()
    {
        mouseFollow = FindObjectOfType<MouseFollow>();
        
    }

    // Update is called once per frame
    new void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (mouseFollow.canAttack)
            {
                anim.SetTrigger("isAttacked");
                siren.SetActive(true);
            }
            
        } 
    }
}
