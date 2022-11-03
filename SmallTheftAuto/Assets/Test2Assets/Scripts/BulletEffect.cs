using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEffect : MonoBehaviour, IWeaponEffect
{
    private Ammo ammo;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        ammo = GetComponent<Ammo>();
    }

    public void SpawnEffect()
    {
        if (ammo.TryConsume())
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
        else
        {
            // play empty mag sound
        }
    }
}
