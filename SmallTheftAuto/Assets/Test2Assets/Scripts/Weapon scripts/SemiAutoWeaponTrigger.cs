using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiAutoWeaponTrigger : MonoBehaviour
{
    public float cooldownDuration = 0.3f;
    private bool onCooldown;
    private IWeaponEffect weaponEffect;

    // Start is called before the first frame update
    void Start()
    {
        weaponEffect = GetComponent<IWeaponEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !onCooldown)
        {
            weaponEffect.SpawnEffect();
            StartCoroutine(StartCooldown());
        }

        if (Input.GetButtonDown("ReloadInput"))
        {
            weaponEffect.ReloadEffect();
        }
    }

    public IEnumerator StartCooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(cooldownDuration);
        onCooldown = false;
    }
}
