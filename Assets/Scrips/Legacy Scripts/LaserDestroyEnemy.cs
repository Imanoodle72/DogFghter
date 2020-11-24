using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDestroyEnemy : MonoBehaviour
{
    private float distanceFromPrefab;
    private Transform prefab;

    public ParticleSystem voidParticle;
    public ParticleSystem hitParticle;

    // Start is called before the first frame update
    void Start()
    {
        prefab = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (prefab != null)
        {
            DetectDistance();
        }
        
        DestroyFar();
    }

    void DetectDistance()
    {
        distanceFromPrefab = Vector3.Distance(transform.position, prefab.position);
    }

    void DestroyFar()
    {
        if (distanceFromPrefab > 1000)
        {
            Explode(voidParticle);
            Explode(hitParticle);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Enemy"))
        {
            Explode(hitParticle);
        }
    }

    void Explode(ParticleSystem particleType)
    {
        Instantiate(particleType, transform.position, particleType.transform.rotation);
        Destroy(gameObject);
    }
}
