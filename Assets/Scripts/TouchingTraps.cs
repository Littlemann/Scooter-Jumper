using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingTraps : MonoBehaviour
{
   [SerializeField] GameObject _lava1;
   [SerializeField] GameObject _lava2;
   private void Start() 
   {
      _lava1.SetActive(false);
      _lava2.SetActive(false);
   }
   private void OnTriggerEnter(Collider other) 
   {
      if(other.CompareTag("LavaTrigger"))
     {
        _lava1.SetActive(true);
        _lava2.SetActive(true);
     }
     if(other.CompareTag("Lava"))
     {
       
        gameObject.SetActive(false);
        
     }
     
   }
}
