using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questobject : MonoBehaviour
{
   public GameObject Questtrigger;
   public GameObject Quest;
   public GameObject Arrow;
   public GameObject Steak;


   private void OnTriggerEnter(Collider other)
   {
      Arrow.SetActive(false);
      Quest.SetActive(true);
      Steak.SetActive(true);
      Questtrigger.SetActive(false);
      Invoke("questvanish",3f);
    
   }

   void questvanish()
   {
      Quest.SetActive(false);
     
   }
   
}
