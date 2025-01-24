using UnityEngine;
using UnityEngine.InputSystem;



public class FishController : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction moveAction;
    public float moveSpeed = 3f;


    public int coinCount = 0;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        // Get the movement input (Vector2)
        Vector2 direction = moveAction.ReadValue<Vector2>();

        // Move the player based on input (we use x and y for movement)
        transform.position += new Vector3(direction.x, direction.y, 0) * Time.deltaTime * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Debug.Log("Coisn");
            coinCount++;
            Destroy(collision.gameObject);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Coin"))
    //    {
    //        Debug.Log("Coin");
    //        coinCount++;
    //    }
    //}

}
