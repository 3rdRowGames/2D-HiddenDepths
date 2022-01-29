using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark:MonoBehaviour
{
    public static Shark instance;
    internal Animator anim;
    public float sharkSpeed;
    internal float speed;
    internal float stun;
    internal OctoController player;
    internal Transform bite;
    internal float biteDistance;
    internal float biteDamage;
    internal float biteCounterMax;
    internal float biteCounter;

    private void Awake()
    {
        instance = this;
        anim = GetComponent<Animator>();
        bite = GetComponentInChildren<Transform>();        
    }

    public void Update()
    {
        if (player != null)
        {            
            //Turn Shark to player
            transform.rotation = (player.transform.position.x < transform.position.x) ? Quaternion.Euler(0f, 180f, 0f) : Quaternion.Euler(0f, 0f, 0f);
            //Increase Max Speed
            if (GameManager.instance.sharkFasterWhenEating) sharkSpeed = 2 + .02f * GameManager.instance.gameScore;
            else sharkSpeed += .15f * Time.deltaTime;
            //Get Current Speed
            speed = (stun >= 0) ? 1 : sharkSpeed;
            //Lower stun Timer in needed
            if (stun >= 0) stun -= Time.deltaTime;           
            //Move Shark
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            //Biting
            if (biteCounter > 0) biteCounter -= Time.deltaTime;
            if (Vector3.Distance(player.transform.position, bite.transform.position)<=biteDistance)
            {
                if(biteCounter <= 0)
                { 
                    anim.SetTrigger("isAttacking");
                    SoundManager.instance.sound.PlayOneShot(SoundManager.instance.sharkBite);
                    biteCounter = biteCounterMax;
                }                
            }
        }
    }
}