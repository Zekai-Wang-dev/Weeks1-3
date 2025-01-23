using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{

    public Transform transform;

    public Vector2 direction;

    public float speed = 5f; 

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

        direction.x = Input.GetAxis("Horizontal");

        transform.Translate(direction.x * speed, 0, 0);

        
    }
}
