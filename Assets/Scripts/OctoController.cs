using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OctoController : MonoBehaviour
{
    public GameObject deathWindow;
    public GameObject playerHud;

    //Octopus Stats
    public float health;

    public Animator anim;
    public ParticleSystem inkParticle;

    MouseFollow mouseFollow;
    Shark shark;

    public float inkRegenRate;

    public TMP_Text timerText;
    public float gameTimer;
    float timer;

    public TMP_Text scoreText;
    public TMP_Text deathScreenScoreText;

    public float gameScore;

    public float inkStat;
    public float sharkSpeed;

    public float damageStat;

    public Slider healthBarSlider;
    public Slider inkBarSlider;


    [SerializeField]
    private Vector3 ScaleWhenEating;

    private void Start()
    {
        mouseFollow = GetComponent<MouseFollow>();
        shark = FindObjectOfType<Shark>();
        Time.timeScale = 1f;
        timer = gameTimer;
    }



    // Update is called once per frame
    void Update()
    {
        InkAbility();

        //Timer
        timer -= 1 * Time.deltaTime;
        var time = (int)timer;
        timerText.SetText(time.ToString());

        //ScoreText
        scoreText.SetText(gameScore.ToString());
        deathScreenScoreText.SetText(gameScore.ToString());

        if (timer <= 0) Death();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Shark") Damage();

        if (collision.gameObject.tag == "Fish")
        {
            if (mouseFollow.canAttack)
            {
                SoundManager.instance.sound.PlayOneShot(SoundManager.instance.squidBite);
                Fish fish = collision.GetComponent<Fish>();
                if (fish.toEat)
                {
                    inkStat++;
                    timer++;
                    gameScore += 10;
                    shark.speed = gameScore * 0.02f; //Shark Speed starts at .02 and slowly goes up by .02
                }
                else
                {
                    timer -= 5;
                    //bad Stuff

                }
                fish.Death();
                anim.SetBool("Attack", true);
            }
        }
    }
    
    public void InkAbility()
    {
        if (Input.GetMouseButtonDown(1) && inkStat >= 100)
        {
            inkStat = 0;
            anim.SetTrigger("InkAbility");
            SoundManager.instance.sound.PlayOneShot(SoundManager.instance.ink);
            Instantiate(inkParticle, transform.position, Quaternion.identity);
        }
        //Setting Ink back to 100
        if (inkStat<=0) inkStat += inkRegenRate * Time.deltaTime;
        inkBarSlider.value = (inkStat >= 0)?100:inkStat;
        inkBarSlider.value = inkStat;
    }


    public void Death()
    {
        deathWindow.SetActive(true);
        playerHud.SetActive(false);
        Time.timeScale = 0.1f;
        SoundManager.instance.sound.PlayOneShot(SoundManager.instance.death);
        Destroy(gameObject);
    }

    public void Damage()
    {
        health -= damageStat * Time.deltaTime;
        if (health <= 0) Death();
        else healthBarSlider.value = health;
    }
}