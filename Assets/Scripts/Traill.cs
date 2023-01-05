using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traill : MonoBehaviour
{
     [SerializeField] TrailRenderer trailRenderer;
     [SerializeField] TrailRenderer trailRenderer2;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _ground;
    
    
    void Start()
    {
      
        trailRenderer.time = 5;
        trailRenderer.material.color = Color.black;
        trailRenderer.startWidth = 0.1f;
        trailRenderer.endWidth = 0.001f;
        
        trailRenderer2.time = 5;
        trailRenderer2.material.color = Color.black;
        trailRenderer2.startWidth = 0.1f;
        trailRenderer2.endWidth = 0.001f;
    }
    void Update()
    {
        
        if(IsGrounded())
        {
        
        trailRenderer.enabled = true;
        trailRenderer2.enabled = true;
        }
        else
        {
            trailRenderer.enabled = false;
            trailRenderer2.enabled = false;
        }
        
        
    }
     bool IsGrounded()
   {
     return Physics.CheckSphere(_groundCheck.position, .1f, _ground );
   }
}
