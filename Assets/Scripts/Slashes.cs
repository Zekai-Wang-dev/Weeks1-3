using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Slashes : MonoBehaviour
{
    public SpriteRenderer sr; 
    public AnimationCurve curve; 

    [Range(0, 1)]
    public float t;
    public int count; 

    public List<Vector3> position;

    // Start is called before the first frame update
    void Start()
    {
        t = Time.deltaTime*1.5f; 
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime*1.5f;

        if (Input.GetMouseButtonDown(0))
        {
            addPos();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            deletePos();
        }

        if (count + 1 >= position.Count)
        {

            transform.position = Vector3.Lerp(position[count], position[0], t);
            transform.up = position[0];
            transform.localScale = new Vector3(0.13f, 10*curve.Evaluate(t), 1);
            sr.color = new Color(0, 0, 1, curve.Evaluate(t));

            if (transform.position == position[0])
            {
                count = 0;
                t = 0; 
            }

        }
        else if (count + 1 < position.Count)
        {

            transform.position = Vector3.Lerp(position[count], position[count + 1], t);
            transform.up = position[count];
            transform.localScale = new Vector3(0.13f, 10*curve.Evaluate(t), 1);
            sr.color = new Color(0, 0, 1, curve.Evaluate(t));

            if (transform.position == position[count + 1])
            {

                count++;
                t = 0;

            }

        }


    }

    public void addPos()
    {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        position.Add(mousePos);

    }

    public void deletePos()
    {
        position.RemoveAt(position.Count - 1);
        count = 0; 
        
    }

}
