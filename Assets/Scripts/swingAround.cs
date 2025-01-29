using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swingAround : MonoBehaviour
{
    //Intialize the time value to keep track on where the rotation is at 
    public float t; 

    //Values to change the speed and rotation of the game object
    public float rotateSpeed;
    public Transform transform;
    public bool reverseRotate = false; 

    // Start is called before the first frame update
    void Start()
    {
        //Initialize values so the professor doesn't have to do so
        t = 0f; 
        rotateSpeed = 0.005f; 
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate the game object to a certain angle to make it seem like its flowing with the wind 
        transform.Rotate(new Vector3(0, 0,  t * rotateSpeed));

        //Once it reaches around 3 seconds, rotate the other way 
        if (t >= 3f)
        {
            reverseRotate = false; 
        }
        else if (t <= 0f)
        {
            reverseRotate = true; 
        }

        //Add to time if the rotation is supposed to be reversed
        if (reverseRotate == true)
        {
            t += Time.deltaTime;
            rotateSpeed = 0.005f; 
        }
        //Subtract to time if the rotation is supposed to be reversed
        else
        {
            t -= Time.deltaTime;
            rotateSpeed = -0.005f; 
        }
    }
}
