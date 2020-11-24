using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMoveForward : MonoBehaviour
{
    public float speed = 600f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Forward();
    }

    void Forward()
    {
        // Speed of laser
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
