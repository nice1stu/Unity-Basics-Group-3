using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Arrowbounce : MonoBehaviour
{
    public GameObject Arrow;
    public GameObject Questtrigger;
    public float amp;
    public float freq;
    private Vector3 initpos;

    private void Start()
    {
        initpos = transform.position;
    }

   

    void Update()
    {
       
            transform.position = new Vector3(23.73f, Mathf.Sin(Time.time * freq) * amp + initpos.y, 9.266f);
          
        
        
        
        
    }
}
