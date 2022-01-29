using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    [SerializeField]
    public Texture2D cursorMain;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public bool canAttack; //Checking if the player can attack 


    Vector3 mousePosition;
    [SerializeField]
    public float moveSpeed; // = 0.1f;
    Rigidbody2D rb;
    Vector2 position = new Vector2(0f, 0f);

    // Start is called before the first frame update

    
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        Cursor.SetCursor(cursorMain, hotSpot, cursorMode);
        
    }

    // Update is called once per frame
    void Update()
    {



        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        position = Vector2.Lerp(transform.position, mousePosition, moveSpeed); // * Time.deltaTime); 

        //Clamp Player Position to a Fixed Playable Area
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -17f, 17f), Mathf.Clamp(transform.position.y, -8f, 5f), transform.position.z);


    }

    private void FixedUpdate()
    {

        rb.MovePosition(position);
        faceMouse();

        //transform.Rotate(mousePosition);
        //    
    }


    public void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );

        //Octopus Faces the mouse with his tenticles out
        if (Input.GetMouseButton(0))
        {
            transform.up = -direction;
            moveSpeed = .025f; //12f;
            canAttack = true;
            
        }
        //Octopus follows the mouse leading with his head
        else
        {
            transform.up = direction;
            moveSpeed = .05f; //15f;
            canAttack = false;
        }
    }

}
