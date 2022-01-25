using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource sound;
    public AudioClip death;
    public AudioClip ink;
    public AudioClip sharkBite;
    public AudioClip squidBite;


    private void Awake()
    {
        instance = this;
        sound = Instantiate(sound);
    }
}
