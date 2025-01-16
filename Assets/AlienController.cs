using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{

    public Transform transform;

    public bool mousePressed;

    public int button; 

    private void Awake()
    {
        transform = GetComponent<Transform>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        mousePressed = Input.GetMouseButtonDown(button);

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePressed && (mousePos - transform.position).magnitude < 1.0f)
        {

            transform.position = new Vector3(mousePos.x, mousePos.y, 0);
            

        }

        
    }
}
