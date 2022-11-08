using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour, IDamageable
{
    public NumericValue hp;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        Mathf.Clamp(hp.value -= damage, 0, 100);
        if (hp.value <= 0)
        {
            Death();
        }
    }

    public void Heal(int healAmount)
    {
        Mathf.Clamp(hp.value += healAmount, 0, 100);
    }

    void Death()
    {
        
    }
}
