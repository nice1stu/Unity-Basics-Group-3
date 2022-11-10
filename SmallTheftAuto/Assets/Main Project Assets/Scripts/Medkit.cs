using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    public int addedHealth = 25;
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.TryGetComponent(out PlayerStatus playerStatus))
        {
            playerStatus.Heal(addedHealth);
            Destroy(gameObject);
        }
    }
}
