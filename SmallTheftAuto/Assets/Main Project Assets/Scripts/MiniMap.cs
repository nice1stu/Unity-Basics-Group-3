using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform playerCore;

    private void LateUpdate() //called after Fixed & update so updates after player has moved
    {
        Vector3 newPosition = playerCore.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
        
        //transform.rotation = Quaternion.Euler(90f, playerCore.eulerAngles.y, 0f); //rotate map with player
    }
}
