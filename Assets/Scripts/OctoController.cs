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
    public float inkRegenRate;

    public TMP_Text timerText;
    public float gameTimer;
    float timer;

    public TMP_Text scoreText;
    public TMP_Text deathScreenScoreText;    

    public float inkStat;

    public Slider healthBarSlider;
    public Slider inkBarSlider;


    [SerializeField]
    private Vector3 ScaleWhenEating;

    private void Start()
    {
        mouseFollow = GetComponent<MouseFollow>();
        Time.timeScale = 1f;
        timer = gameTimer;
        Shark.instance.player = this;
    }

    void Update()
    {
        InkAbility();

        //Timer
        timer -= 1 * Time.deltaTime;
        var time = (int)timer;
        timerText.SetText(time.ToString());

        //ScoreText
        scoreText.SetText(GameManager.instance.gameScore.ToString());
        deathScreenScoreText.SetText(GameManager.instance.gameScore.ToString());

        if (timer <= 0) Death();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Shark") Health(-Shark.instance.biteDamage);
        if (collision.gameObject.tag == "Fish")
        {            
            if (mouseFollow.canAttack)
            {
                SoundManager.instance.sound.PlayOneShot(SoundManager.instance.squidBite);
                Fish fish = collision.GetComponent<Fish>();
                inkStat++;
                timer++;
                Health(10);
                GameManager.instance.gameScore += 10; 
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
        if (inkStat < 100) inkStat += (GameManager.instance.gameScore >= 500 && inkStat <= 10) ? inkStat += (inkRegenRate + 0.1f) * Time.deltaTime: inkRegenRate * Time.deltaTime;
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

    public void Health(float value)
    {
        Debug.Log(value);
        health = (health + value>=100)?100:(health+value<=0)?0:health+value;
        if (health <= 0) Death();
        else healthBarSlider.value = health;
    }    
}