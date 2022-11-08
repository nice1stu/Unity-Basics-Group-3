using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponEffect : MonoBehaviour
{
    public float cooldownDuration = 0.3f;
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
        hitCol.enabled = true;
        hitParticle.Play();
        StartCoroutine(StartCooldown());
        hitCol.enabled = false;
    }
    
    private void OnTriggerEnter(Collider col)
    {
        
    }
    
    public IEnumerator StartCooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(cooldownDuration);
        onCooldown = false;
    }
}
