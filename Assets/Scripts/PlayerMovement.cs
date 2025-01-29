using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Intialization of all the variables to move the game object 
    public float speed; 
    public Vector2 velocity;
    public Transform transform;
    public bool switchDirection; 

    //Maximum and minimum point in y value to which the game object moves to 
    public float maxY;
    public float minY; 

    // Start is called before the first frame update
    void Start()
    {
        //Intialize all the values here so that the professor doesn't have to manuel do so 
        speed = 0.0001f; 
        velocity.y = speed; 
        maxY = transform.position.y + 0.1f;
        minY = transform.position.y - 0.1f;

    }

    // Update is called once per frame
    void Update()
    {
        
        //Make the position go down once it reaches a maximum value so it doesn't keep going forever
        if (transform.position.y >= maxY)
        {
            velocity.y = -speed;

        }
        //Makes the position go up once it reaches a minimum value so it doesn't keep going forever
        else if (transform.position.y <= minY)
        {
            velocity.y = speed;

        }

        //Change the position of the game object 
        transform.position = new Vector2(transform.position.x, transform.position.y + velocity.y);

    }
}
