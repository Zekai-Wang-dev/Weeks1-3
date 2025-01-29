using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Slashes : MonoBehaviour
{

    //Initialize spirit renderer to change transparency so that the slashes appear to come out of nowhere 
    public SpriteRenderer sr; 

    //Curve to act with the transparency 
    public AnimationCurve curve; 

    //Range for the time for the curve
    [Range(0, 1)]
    public float t;

    //An int that counts the number of loops and positions so that the slashes go in order 
    public int count; 

    //A list that stores all the position of the slashes so that it could be used later for effects 
    public List<Vector3> position;

    //A boolean to start the slashes so that it makes it seem like the player is attacking 
    public bool slashing = false;

    //Speed of the slashes so that it's easier to control what makes the slashes appear better
    public float slashSpeed; 

    // Start is called before the first frame update
    void Start()
    {
        //Initialize the time so that I could add to the variable instead of making t just time. 
        t = 0;

        //Initialize the speed value so that the professor doesn't have to do it
        slashSpeed = 4f; 

        //Add a starting position so that the below code does not return null and it also makes it look like the slashes came from the person 
        position.Add(new Vector3(13, -10, 0));
    }

    // Update is called once per frame
    void Update()
    {

        //Add a position once the player left clicks so that they could store wherever they want the slashes to be
        if (Input.GetMouseButtonDown(0))
        {
            addPos();
        }

        //When the player right clicks, start the slashing sequence so that it makes it seem like the player is attacking
        else if (Input.GetMouseButtonDown(1))
        {
            slashing = true;
        }

        //Start the slashing sequence from a list of wherever the player clicked
        if (slashing == true)
        {
            //Count the time for the curve
            t += Time.deltaTime * slashSpeed;

            //Checks if the current slash is the last slash and make it go back to the original point 
            if (count + 1 >= position.Count)
            {
                //Variables to change the position of the slash as well its scale and transparency 
                transform.position = Vector3.Lerp(position[count], position[0], t);
                transform.up = position[0];
                transform.localScale = new Vector3(0.13f, 10 * curve.Evaluate(t), 1);
                sr.color = new Color(0, 0, 1, curve.Evaluate(t));

                //Change the color of the slash to red so that it shows the enemy getting hit 
                if (transform.position.x >= -1.56 && transform.position.y <= 2.51 && transform.position.x <= 1.95 && transform.position.y >= -2.93)
                {
                    sr.color = new Color(1, 0, 0, curve.Evaluate(t));
                }

                //Return all values to default when the loop ends
                if (transform.position == position[0])
                {
                    count = 0;
                    t = 0;
                    slashing = false;
                    position.Clear();
                    position.Add(new Vector3(13, -10, 0));

                }

            }
            //Checks if the current slash is not the last slash 
            else if (count + 1 < position.Count)
            {
                //Changes the position of the slash as well as its scale and transparency 
                transform.position = Vector3.Lerp(position[count], position[count + 1], t);
                transform.up = position[count+1];
                transform.localScale = new Vector3(0.13f, 10 * curve.Evaluate(t), 1);
                sr.color = new Color(0, 0, 1, curve.Evaluate(t));

                //Change the color of the slash to red so that it shows the enemy getting hit
                if (transform.position.x >= -1.56 && transform.position.y <= 2.51 && transform.position.x <= 1.95 && transform.position.y >= -2.93)
                {
                    sr.color = new Color(1, 0, 0, curve.Evaluate(t));
                }

                //Count up the amount of slashes occured and reset the time to 0 so that the slashes could continue 
                if (transform.position == position[count + 1])
                {

                    count++;
                    t = 0;

                }

            }
        }


    }

    //A method to add the position based on where the player clicked so that it feels like the player did the slashes
    public void addPos()
    {

        //gets mouse position based on the position of the mouse in the game world 
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Get the mouse position to be 0 so that it's not out of camera view. 
        mousePos.z = 0;

        position.Add(mousePos);

    }



}
