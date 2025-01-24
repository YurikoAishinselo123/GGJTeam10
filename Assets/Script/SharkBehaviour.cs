using UnityEngine;

public class SharkBehaviour : MonoBehaviour
{
    public float speed = 2f; 
    public float distance = 5f; 
    private Vector3 startPosition; 
    private float time; 


    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * speed;
        float offset = Mathf.PingPong(time, distance); 
        transform.position = startPosition + new Vector3(offset, 0, 0);
    }
}
