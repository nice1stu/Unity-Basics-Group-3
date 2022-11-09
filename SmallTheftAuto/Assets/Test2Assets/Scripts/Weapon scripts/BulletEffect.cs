using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEffect : MonoBehaviour, IWeaponEffect
{
    public int damage = 25;
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
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            if (bullet.TryGetComponent(out Rigidbody rb))
            {
                rb.velocity = rb.transform.forward * 20;
            }

            if (bullet.TryGetComponent(out Bullet bulletScript))
            {
                bulletScript.damage = damage;
            }
            //play shoot sound
        }
        else
        {
            // play empty mag sound
        }
    }

    public void ReloadEffect()
    {
        if (ammo.TryReload())
        {
            Debug.Log("Reloaded");
            //play reload sound
        }
    }
}
