using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualWeaponTrigger : MonoBehaviour
{
    private IWeaponEffect weaponEffect;

    // Start is called before the first frame update
    void Start()
    {
        weaponEffect = GetComponent<IWeaponEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            weaponEffect.SpawnEffect();
        }

        
    }
}
