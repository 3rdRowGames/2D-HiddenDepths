using UnityEngine;
using UnityEngine.Tilemaps;

public class Movement : MonoBehaviour
{
    /*    private BoxCollider2D boxCollider;
        public static Movement instance;

        [SerializeField] int moveSpeed = 1;
        [SerializeField] Rigidbody2D playerBody;
        [SerializeField] Animator playerAnimator;

        public string transitionName;

        private Vector3 bottomLeftEdge;
        private Vector3 topRightEdge;
        [SerializeField] Tilemap tilemap;


    */
    Rigidbody2D rbd2;
    
    //private float moveSpeed = 3;

    public const string RIGHT = "right";
    public const string LEFT = "left";

    
    bool isJumpPressed;

    private void Start()
    {
        /*if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
          instance = this;
        }

        DontDestroyOnLoad(gameObject);

        bottomLeftEdge = tilemap.localBounds.min;
        topRightEdge = tilemap.localBounds.max;*/

        rbd2 = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 0f, 0f);
            transform.position += transform.right * (Time.deltaTime * 5);
            /*SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = false;*/


        }

        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 180f, 0f);
            transform.position -= transform.right * (Time.deltaTime * 5);
          /*  SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = true;*/

        }


        if (Input.GetKey(KeyCode.Space))
        {                                                                                                                                       
            isJumpPressed = true;
        }
    }


    private void FixedUpdate()
    {
        /*float x = Input.GetAxisRaw("Horizontal") ;
        float y = Input.GetAxisRaw("Vertical");

        playerBody.velocity = new Vector2(x, y) * moveSpeed * Time.deltaTime;

        playerAnimator.SetFloat("movementX", playerBody.velocity.x);
        playerAnimator.SetFloat("movementY", playerBody.velocity.y);

        if(x == 1 || x == -1 || y == 1 || y == -1)
        {
            playerAnimator.SetFloat("IdleX",x);
            playerAnimator.SetFloat("IdleY",y);
        }

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, bottomLeftEdge.x, topRightEdge.x),
            Mathf.Clamp(transform.position.y, bottomLeftEdge.y, topRightEdge.y),
            Mathf.Clamp(transform.position.z, bottomLeftEdge.z, topRightEdge.z)
        );*/
        /*if (buttonPressed == RIGHT)
        {
            rbd2.AddForce(new Vector2(moveSpeed, 0),ForceMode2D.Force);
        }
        else if (buttonPressed == LEFT)
        {
            rbd2.AddForce(new Vector2(-moveSpeed, 0), ForceMode2D.Force);
        }
        else
        {
           
        }*/

        if (isJumpPressed)
        {
            rbd2.AddForce(Vector2.up, ForceMode2D.Impulse);
            isJumpPressed = false;
        }
    
    }
}