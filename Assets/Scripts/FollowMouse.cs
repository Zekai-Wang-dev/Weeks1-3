using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{


    public Transform transform;
    public Vector2 mousePos;

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


        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //mousePos.z = Camera.main.nearClipPlane;

        transform.position = new Vector3(mousePos.x + 2, mousePos.y); 
    }

}
