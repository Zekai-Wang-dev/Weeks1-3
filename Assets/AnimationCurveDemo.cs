using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCurveDemo : MonoBehaviour
{

    public AnimationCurve curve;

    public float t1;

    [Range(0, 100)] public float t;


    // Start is called before the first frame update
    void Start()
    {
        t1 = Time.deltaTime; 

    }

    // Update is called once per frame
    void Update()
    {

        t1 += Time.deltaTime; 
        if (t1 > 1)
        {
            t1 = 0; 
        }

        transform.localScale = Vector2.one * curve.Evaluate(t1);

    }
}
