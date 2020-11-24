using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnLaserHitShip : MonoBehaviour
{
    public int playerHealth;
    public ParticleSystem explosionParticle;
    public ParticleSystem fireParticle;

    private GameManager gameManager;
    private PlayerController control;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        control = GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        NegativePreventer();
        PlayerDown();
        
        gameManager.UpdateHealth(playerHealth);
    }

    void PlayerDown()
    {
        if (playerHealth == 0)
        {
            Instantiate(fireParticle, transform.position, explosionParticle.transform.rotation);
            control.enabled = false;
            gameManager.GameOver(true);
        }

        
    }

    void NegativePreventer()
    {
        if (playerHealth < 0)
        {
            playerHealth = 0;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("LaserE"))
        {
            playerHealth -= 1;
            
        }
    }
}
