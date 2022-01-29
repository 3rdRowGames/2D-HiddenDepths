using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ink : MonoBehaviour
{
    public float inkTimer;
    void Update()
    {
        inkTimer -= 1 * Time.deltaTime;
        if (inkTimer <= 0) Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shark") Shark.instance.stun = 2f;
    }
}
