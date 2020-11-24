using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLaserHitShip : MonoBehaviour
{
    public int health;
    public ParticleSystem explosionParticle;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            Destroy(gameObject);
            gameManager.UpdateKill(1);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("LaserP"))
        {
            health -= 1;
        }
    }
}
