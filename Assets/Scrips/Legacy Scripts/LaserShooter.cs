using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float fireRate = 0.09375f;

    private float lastShot = 0f;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ShootLaser();
    }

    void ShootLaser()
    {
        if (Input.GetMouseButton(0) && gameManager.isGameActive == true)
        {
            if (Time.time > fireRate + lastShot)
            {
                Instantiate(projectilePrefab, transform.position, transform.rotation);
                lastShot = Time.time;
            }
        }
        
    }
}
