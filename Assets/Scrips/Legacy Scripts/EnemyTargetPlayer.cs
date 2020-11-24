using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetPlayer : MonoBehaviour
{
    public float velocity;
    public float thrustMultiplier;
    public float turnForce;
    public float distance;

    private GameObject target;
    private Rigidbody enemyRB;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.Find("Player");
        distance = Vector3.Distance(enemyRB.transform.position, target.transform.position);

        Thrust();
        PointOfAttack();
    }

    void PointOfAttack()
    {
        if (distance > 300)
        {
            LookAt(target.transform.position);
        }

        if (distance < 100)
        {
            LookAway(target.transform.position);
        }
        else
        if (distance > 450)
        {
            LookAt(target.transform.position);
        }
    }

    void LookAt(Vector3 tg)
    {
        Vector3 targetDelta = tg - transform.position;
        float angleToTarget = Vector3.Angle(transform.forward, targetDelta);
        Vector3 turnAxis = Vector3.Cross(transform.forward, targetDelta);
        enemyRB.AddTorque(turnAxis * angleToTarget * turnForce);
    }

    void LookAway(Vector3 tg)
    {
        Vector3 targetDelta = transform.position - tg;
        float angleToTarget = Vector3.Angle(transform.forward, targetDelta);
        Vector3 turnAxis = Vector3.Cross(transform.forward, targetDelta);
        enemyRB.AddTorque(turnAxis * angleToTarget * turnForce);
    }

    void Thrust()
    {
        enemyRB.AddForce(enemyRB.transform.forward * velocity * thrustMultiplier * Time.deltaTime, ForceMode.Impulse);
    }
}
