using UnityEngine;
using UnityEngine.InputSystem;



public class FishController : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction moveAction;
    public float moveSpeed = 3f;


    public int coinCount = 0;
    private bool isTurn = false;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Facing();
        Debug.Log("is Turn " + isTurn);
    }

    void Movement()
    {
        // Get the movement input (Vector2)
        Vector2 direction = moveAction.ReadValue<Vector2>();

        // Move the player based on input (we use x and y for movement)
        transform.position += new Vector3(direction.x, direction.y, 0) * Time.deltaTime * moveSpeed;
    }

    void Facing()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();

        if (isTurn && direction.x != 0)
        {
            isTurn = true;
            if (direction.x > 0)  
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);  
            }
            else if (direction.x < 0)  
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);  
            }
        }
        else if (!isTurn && direction.y != 0)
        {
            isTurn = false;

            if (direction.y > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (direction.y < 0) 
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            coinCount++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Shark"))
        {
            Debug.Log("Die");
        }
        if (collision.gameObject.CompareTag("Forward_Back"))
        {
            isTurn = false;
            Debug.Log("Forward");
        }
        if (collision.gameObject.CompareTag("Left_Right"))
        {
            isTurn = true;
            Debug.Log("Turn");
        }
    }

}
