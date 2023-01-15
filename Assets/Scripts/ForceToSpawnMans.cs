using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceToSpawnMans : MonoBehaviour
{
    Rigidbody _eRb;
    [SerializeField] private float _speedY;
    [SerializeField] private float _speedZ;
    void Start()
    {
        _eRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update() 
    {
        
        _eRb.AddForce( new Vector3(0,_speedY,_speedZ) , ForceMode.Impulse); 
        
    }
}
