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
    private Collider hitCol;
    
    
    // Start is called before the first frame update
    void Start()
    {
        hitCol = GetComponent<Collider>();
        hitCol.enabled = false;
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
        Physics.SphereCast(transform.position, hitRadius, Vector3.forward, out RaycastHit hit, 1, hitLayer);
        if (hit.collider.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(damage);
        }
        
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
