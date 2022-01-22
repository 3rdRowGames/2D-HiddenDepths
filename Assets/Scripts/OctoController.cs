using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OctoController : MonoBehaviour
{
    public GameObject deathWindow;

    //Octopus Stats
    public bool isHungry;
    public float hungerStat;

    MouseFollow mouseFollow;
    Shark shark;

    public float maxHungerTimer;
    public float hungerTimer;
    public float hungerDecayRate;
    public float inkDecayRate;
    public bool isDead = false;

    public TMP_Text timerText;
    public float gameTimer;
    float timer;

    public float inkStat;

    public float damageStat;

    public Slider healthBarSlider;
    public Slider inkBarSlider;


    [SerializeField]
    private Vector3 ScaleWhenEating;

    private void Start()
    {
        mouseFollow = GetComponent<MouseFollow>();
        shark = GetComponent<Shark>();
        timer = gameTimer;
    }



    // Update is called once per frame
    void Update()
    {
        CheckHunger();
        Dead();
        InkAbility();

        //Timer
        timer -= 1 * Time.deltaTime;
        var time = (int)timer;
        timerText.text = time.ToString();

        if (timer <= 0)
        {
            isDead = true;
            timer = 0;
        }

            
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if ((collision.gameObject.tag == "Shark"))
        {
            Damage();
            if (hungerStat == 0)
            {
                isDead = true;
            }

        }

        if ((collision.gameObject.tag == "Fish"))
        {
            if (mouseFollow.canAttack)
            {
                Fish fish = collision.GetComponent<Fish>();
                if (fish.toEat)
                {
                    //good stuff
                    if (isHungry)
                    {
                        hungerStat++;
                        inkStat++;
                    }
                }
                else
                {
                    //bad Stuff

                }            

                hungerTimer++;
                fish.Death();
            }

        }
    }

    public void CheckHunger()
    {
        healthBarSlider.value = hungerStat;
        if (hungerStat >= 0)
        {
            isHungry = true;
        }

        if (hungerStat >= 100)
        {
            hungerStat = 100;
            isHungry = false;
        }

        if (hungerStat <= 0)
        {
            Destroy(gameObject);
            isDead = true;
        }

        hungerTimer -= hungerDecayRate * Time.deltaTime;
        if (hungerTimer >= maxHungerTimer)
        {
            hungerTimer = maxHungerTimer;
        }
        if (hungerTimer <= 0)
        {
            hungerStat -= hungerDecayRate * Time.deltaTime;
            hungerTimer = 0;
        }
            
    }

    public void InkAbility()
    {
        if (Input.GetMouseButtonDown(1) && inkStat >= 25)
        {
            inkStat = inkStat - 25;
        }

        //Setting Ink back to 100
        if (inkStat >= 100)
        {
            inkStat = 100;
        }

        if (inkStat >= 0)
        {
            inkStat += inkDecayRate * Time.deltaTime;
        }

        inkBarSlider.value = inkStat;
    }


    public void Dead()
    {
        if (isDead)
        {
            deathWindow.SetActive(true);
            Time.timeScale = 0.1f;


            Destroy(gameObject);
        }

        else
        {
            Time.timeScale = 1;
            isDead = false;
        } 
        
    }

    public void Damage()
    {
        hungerStat = hungerStat - damageStat * Time.deltaTime;
    }

}
