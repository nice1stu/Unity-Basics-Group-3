using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponEffect : MonoBehaviour
{
    public int damage = 25;
    public float cooldownDuration = 0.3f;
    public float hitRadius = 1;
    public LayerMask hitLayer;
    
    public ParticleSystem hitParticle;
    private bool onCooldown;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !onCooldown)
        {
            HitEffect();
        }
    }

    void HitEffect()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, hitRadius, Vector3.forward, 1.5f, hitLayer);
        for (var i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(damage);
                Debug.Log("Hit");
            }
        }


        Debug.Log("Tried Hit");
        hitParticle.Play();
        StartCoroutine(StartCooldown());
    }
    
    
    
    public IEnumerator StartCooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(cooldownDuration);
        onCooldown = false;
    }
}
