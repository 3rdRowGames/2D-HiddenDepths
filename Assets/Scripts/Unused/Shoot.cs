using UnityEngine;

public class Shoot : MonoBehaviour
{   

    public GameObject projectile;
    public Transform shootPoint;
    [SerializeField] private KeyCode shootButton;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyDown(shootButton))
        {
            if (projectile == null)
            {
                Debug.Log("No projectile Set");
            }
            else
            {
                Instantiate(projectile, shootPoint.position, transform.rotation);
            }
        }
        
    }
}
