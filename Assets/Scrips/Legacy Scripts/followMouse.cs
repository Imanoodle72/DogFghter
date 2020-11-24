using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followMouse : MonoBehaviour
{
    private GameManager gameManager;

    public float xMousePosition;
    public float yMousePosition;
    //public GameObject cursor;

    Vector2 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        xMousePosition = Input.mousePosition.x;
        yMousePosition = Input.mousePosition.y;

        mousePosition = new Vector2(xMousePosition, yMousePosition);

        transform.position = mousePosition;
    }
}
