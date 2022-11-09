using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    [NonSerialized]public int damage;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision col)
    {
        // if (col.gameObject.layer == )
        // {
        //     
        // }
        if (col.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}