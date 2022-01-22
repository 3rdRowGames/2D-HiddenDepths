using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Fish : MonoBehaviour
{
    public float size;
    public bool rightSide;
    public GameObject target;
    public float speed;
    public string animalName ;
    public bool toEat;
    public GameObject fishNameCanvas;
    public TMP_Text fishNameText;

    

    public void Start()
    {
        fishNameText.SetText(animalName);
    }
    public virtual void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if((rightSide && collision.gameObject.tag == "Left Collider")|| (!rightSide && collision.gameObject.tag=="Right Collider"))
        {
            Death();
        }        
    }

    public void Size(float x)
    {
        size = x;
        transform.localScale = new Vector3(x, x, 1);

        //Updating the Fish Name Canvas Position and Rotation
        fishNameText.transform.localScale = new Vector3 (0.5f/x, 0.5f/x, 1);
        fishNameCanvas.transform.position = (GetComponent<SpriteRenderer>().sprite = GameManager.instance.goodFishSprites[3])?new Vector3(transform.position.x,transform.position.y+.2f,transform.position.z):transform.position;
        fishNameCanvas.transform.rotation = Quaternion.identity;
    }

    internal void Death()
    {
        GameManager.instance.fishInGame.Remove(this);
        Destroy(gameObject);
    }

}
