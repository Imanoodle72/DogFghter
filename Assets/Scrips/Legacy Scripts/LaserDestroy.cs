using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDestroy : MonoBehaviour
{
    private float distanceFromPlayer;
    private Transform player;
    public ParticleSystem voidParticle;
    public ParticleSystem hitParticle;
    // Start is called before the first frame update
    void Start()
    {
        // Finds the transform(location) of GameObject with the tag: Player
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        DetectDistance();
        DestroyFar();
    }

    void DetectDistance()
    {
        // Detects distance of laser from Player
        distanceFromPlayer = Vector3.Distance(transform.position, player.position);
    }

    void DestroyFar()
    {
        if (distanceFromPlayer > 1500)
        {
            Explode(voidParticle);
            Explode(hitParticle);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            Explode(hitParticle);
        }
    }

    void Explode(ParticleSystem particleType)
    {
        Instantiate(particleType, transform.position + new Vector3(0f, 0f, -11f), particleType.transform.rotation);
        Destroy(gameObject);
    }
}
