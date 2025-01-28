using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed; 
    public Vector2 velocity;
    public Transform transform;
    public bool switchDirection; 

    public float maxY;
    public float minY; 

    // Start is called before the first frame update
    void Start()
    {

        speed = 0.0001f; 
        velocity.y = speed; 
        maxY = transform.position.y + 0.1f;
        minY = transform.position.y - 0.1f;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.y >= maxY)
        {
            velocity.y = -speed;

        }
        else if (transform.position.y <= minY)
        {
            velocity.y = speed;

        }

        transform.position = new Vector2(transform.position.x, transform.position.y + velocity.y);

    }
}
