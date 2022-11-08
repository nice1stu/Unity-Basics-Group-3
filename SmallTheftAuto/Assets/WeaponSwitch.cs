using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    private WeaponStates equippedWeapon;
    public GameObject[] weaponSlot;
    
    // Start is called before the first frame update
    void Start()
    {
        equippedWeapon = WeaponStates.Weapon3;
        SwitchWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if (SelectWeapon())
            SwitchWeapon();
    }

    bool SelectWeapon()
    {
        if (Input.GetButtonDown("Weapon1Input"))
        {
            equippedWeapon = WeaponStates.Weapon1;
            return true;
        }
        if (Input.GetButtonDown("Weapon2Input"))
        {
            equippedWeapon = WeaponStates.Weapon2;
            return true;
        }
        if (Input.GetButtonDown("Weapon3Input"))
        {
            equippedWeapon = WeaponStates.Weapon3;
            return true;
        }

        return false;
    }

    void SwitchWeapon()
    {
        if (equippedWeapon == WeaponStates.Weapon1)
        {
            for (int i = 0; i < weaponSlot.Length; i++)
            {
                weaponSlot[i].SetActive(false);
            }
            weaponSlot[0].SetActive(true);
        }
        if (equippedWeapon == WeaponStates.Weapon2)
        {
            for (int i = 0; i < weaponSlot.Length; i++)
            {
                weaponSlot[i].SetActive(false);
            }
            weaponSlot[1].SetActive(true);
        }
        if (equippedWeapon == WeaponStates.Weapon3)
        {
            for (int i = 0; i < weaponSlot.Length; i++)
            {
                weaponSlot[i].SetActive(false);
            }
            weaponSlot[2].SetActive(true);
        }
    }
    
    enum WeaponStates
    {
        Weapon1,
        Weapon2,
        Weapon3
    }
}
