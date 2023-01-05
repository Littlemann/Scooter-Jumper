using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    private Rigidbody _myRb;
    [SerializeField] private float _speed;
    [SerializeField] private float _smallSpeed;
    [SerializeField] private ParticleSystem _friction;
    [SerializeField] private ParticleSystem _fastWind;
    private void Start() 
    {
        _myRb = GetComponent<Rigidbody>();
    }
    private void Update() 
    {
        _friction.transform.position = transform.position;
    }
  
   
    private void OnCollisionExit(Collision other) 
    {
         if(other.gameObject.CompareTag("Boost"))
        {
           
          
           _myRb.velocity = new Vector3(_myRb.velocity.x, 0.75f * _speed, _myRb.velocity.z);
           _friction.Play(true);
           _fastWind.Play(true);
           
           
        }
        if(other.gameObject.CompareTag("LittleBoost"))
        {
         
           _myRb.velocity = new Vector3(_myRb.velocity.x, 0.75f * _smallSpeed, _myRb.velocity.z);
            
        }
    }
}
