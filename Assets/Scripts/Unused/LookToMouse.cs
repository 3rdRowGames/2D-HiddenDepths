using UnityEngine;
using System.Collections;

public class LookToMouse : MonoBehaviour
{

    void Update()
    {
        faceMouse();
    }

    void faceMouse()
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
        }
        //Octopus follows the mouse leading with his head
        else 
        {
            transform.up = direction;
        }
    }







    //original LookAtMouse Script

    /*    void Update()
        {
            //Mouse Position in the world. It's important to give it some distance from the camera. 
            //If the screen point is calculated right from the exact position of the camera, then it will
            //just return the exact same position as the camera, which is no good.
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);

            //Angle between mouse and this object
            float angle = AngleBetweenPoints(transform.position, mouseWorldPosition);

            //Ta daa
            transform.rotation = Quaternion.Euler(new Vector3(180f, 180f, angle));
        }

        float AngleBetweenPoints(Vector2 a, Vector2 b)
        {
            return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
        }
    */
}