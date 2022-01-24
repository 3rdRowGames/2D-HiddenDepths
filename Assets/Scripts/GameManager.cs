using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<Fish> fish;
    public Fish badFish;
    public List<Fish> fishInGame;
    public float spawnTimer;
    public float currentTimer;
    public Sprite badFishSprite;
    public List<Sprite> goodFishSprites;
    public float spawnOutset; //Original was 13
    public int goodFishPercent;
    public List<string> names = new List<string> {
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

    private void Awake()
    {
        instance = this;
        currentTimer = spawnTimer;
    }

    private void Update()
    {
        currentTimer -= Time.deltaTime;
        if (currentTimer <= 0)
        {
            SpawnFish((Random.Range(0, 2) == 0) ? true : false);
            currentTimer = spawnTimer;
        }
    }

    public void SpawnFish(bool right)
    {
        bool makeAGoodFish = (Random.Range(1, 100) <= goodFishPercent) ? true : false;
        
        Fish f = (makeAGoodFish)?Instantiate(fish[Random.Range(0,fish.Count)], new Vector3((right) ? spawnOutset : -spawnOutset, Random.Range(-5f, 1.5f), 0), (right) ? Quaternion.Euler(0f, 180f, 0f) : Quaternion.identity): Instantiate(badFish, new Vector3((right) ? spawnOutset : -spawnOutset, Random.Range(-5f, 1.5f), 0), (right) ? Quaternion.Euler(0f, 180f, 0f) : Quaternion.identity);
        f.toEat = makeAGoodFish;
        f.animalName = names[Random.Range(0, names.Count)];
        f.rightSide = right;
        f.Size(Random.Range(.4f, 1.7f));
        fishInGame.Add(f);

    }


    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

}

