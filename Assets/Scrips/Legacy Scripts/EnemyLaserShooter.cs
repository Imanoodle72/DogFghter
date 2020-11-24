using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform enemyLaserCannon;
    public float fireRate = 0.09375f;

    private float lastShot = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (projectilePrefab.transform != null)
        {
            Debug.Log("transform does not exist");
        }
        */

        if (enemyLaserCannon != null)
        {
            ShootLaser();
        }
        
    }

    void ShootLaser()
    {
        if (Time.time > fireRate + lastShot)
        {
            Instantiate(projectilePrefab, enemyLaserCannon.position, enemyLaserCannon.rotation);
            lastShot = Time.time;
        }
    }
}
