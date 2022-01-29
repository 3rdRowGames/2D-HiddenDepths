using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool sharkFasterWhenEating;
    public Text eatText;
    public float gameScore;
    public static GameManager instance;
    public List<Fish> fish;
    public List<Fish> fishInGame;
    public float spawnTimer;
    public float currentTimer;
    public List<Sprite> goodFishSprites;
    public float spawnOutset; //Original was 13
    internal List<string> names = new List<string> {
        "Angela","Amy", "Anna","Alison","Adam","Alex","Anthony","Alistair","Alfred","Alexa","Ainsley",
        "Beth", "Bonnie", "Bailey","Beuford", "Barbara","Bernard", "Bill", "Bryce", "Belle","Barrie",
        "Carol", "Candice", "Cindy","Cole", "Charles","Chris","Chance", "Caleb","Caddie","Caitlyn", "Connor", "Carl","Conrad",
        "Donna", "Deborah","Doug",  "Don", "Dwight", "Dexter", "Daphne",
        "Elaine", "Emily","Edward", "Eric","Ethan",
        "Farrah","Fred","Frank", "Fran",
        "Gina", "George", "Gerald",
        "Heather",  "Harold","Hank",
        "Isabelle", "Ian", "Igor",
        "Jolene",  "Jake", "James", "Jackson", "Jesse", "John", "Jack", "Janet",
        "Katherine", "Karl", "Keon", "Kevan","Keanu","Konrad",
        "Laura","Lewis","Larry","Lauren","Lawrence",
        "Mary",  "Matt","Martin","Melvin","Maebel", "Maddox","Meagen","Magda","Marvin","Mitch","Micah","Mia","Mark","Micheal",
        "Olivea","Oliver","Oslo",
        "Piper","Phillip","Paul"
    };
    public float sharkStartSpeed;
    public float biteDistance;
    public float fishSpeed;
    public float biteDamage;
    public float biteCounter;
    

    private void Start()
    {
        instance = this;
        currentTimer = spawnTimer;
        Shark.instance.speed = Shark.instance.sharkSpeed = sharkStartSpeed;
        Shark.instance.biteDamage = biteDamage;
        Shark.instance.biteDistance = biteDistance;
        Shark.instance.biteCounterMax = Shark.instance.biteCounter = biteCounter;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.K)) sharkFasterWhenEating = (sharkFasterWhenEating) ? false : true;
        currentTimer -= Time.deltaTime;
        if (currentTimer <= 0)
        {
            SpawnFish((Random.Range(0, 2) == 0) ? true : false);
            currentTimer = spawnTimer;
        }
        eatText.text = (sharkFasterWhenEating)?"Eating Mode: Shark speed - "+ Mathf.Round(Shark.instance.speed *100)/100: "Timing Mode: Shark speed - " + Mathf.Round(Shark.instance.speed * 100) / 100;
    }

    public void SpawnFish(bool right)
    {
        Fish f = Instantiate(fish[Random.Range(0, fish.Count)], new Vector3((right) ? spawnOutset : -spawnOutset, Random.Range(-5f, 1.5f), 0), (right) ? Quaternion.Euler(0f, 180f, 0f) : Quaternion.identity);
        f.animalName = names[Random.Range(0, names.Count)];
        f.speed = fishSpeed;
        f.rightSide = right;
        f.Size(Random.Range(.4f, 1.7f));
        fishInGame.Add(f);
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

}

