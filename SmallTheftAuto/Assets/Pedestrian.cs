using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestrian : MonoBehaviour, IDamageable
{
    public int maxHP = 100;
    private int hp;
    private bool alive = true;
    
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        transform.Rotate(-90,0,0);
    }

    private void Walk()
    {
        
    }
}
