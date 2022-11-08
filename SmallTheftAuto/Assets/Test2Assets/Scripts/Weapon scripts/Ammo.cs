using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int magSize; 
    private int magSizeLeft;
    public int maxSpareAmmo;
    private int spareAmmo;

    private int MagDeficit => magSize - magSizeLeft;
    private int Realoadable => Math.Min(spareAmmo, MagDeficit);

    void Start()
    {
        magSizeLeft = magSize;
        spareAmmo = maxSpareAmmo;
    }
    
    public bool TryConsume()
    {
        if (magSizeLeft == 0)
            return false;
        magSizeLeft--;
        return true;
    }

    public bool TryReload()
    {
        if (Realoadable == 0)
            return false;
        magSizeLeft += Realoadable;
        spareAmmo -= Realoadable;
        return true;
    }
}
