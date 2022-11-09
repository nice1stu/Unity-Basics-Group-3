using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestrian : MonoBehaviour, IDamageable
{
    public bool patrol;
    public int maxHP = 100;
    public int hp;
    private bool alive = true;
    public Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHP;
    }
    public GameObject[] patrolPoints;
    public GameObject currentPatrolPoints;
    public int currentPatrolPointIndex;
    
    public int CurrentMoveSpeed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            if (currentPatrolPointIndex>=patrolPoints.Length-1)
            {
                currentPatrolPointIndex = 0;
            }
            else
            {
                currentPatrolPointIndex++;
            }
            currentPatrolPoints = patrolPoints[currentPatrolPointIndex];
        }
    }
    
    void Patrol()
    {
        transform.LookAt(currentPatrolPoints.transform, Vector3.up);
        rb.velocity = transform.forward * CurrentMoveSpeed;
    }
    void Update()
    {
        if (patrol)
        {
            Patrol();
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0 && alive)
        {
            Die();
        }
    }

    private void Die()
    {
        patrol = false;
        transform.Rotate(-90,0,0);
    }

}
