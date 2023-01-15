using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableColliders : MonoBehaviour
{

    [SerializeField] private LayerMask _ground;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Collider[] m_Collider;
    [SerializeField] private Transform _rampCheck;
    [SerializeField] private Transform _ramp2Check;
    [SerializeField] private LayerMask _ramp;
     bool IsGrounded()
   {
     return Physics.CheckSphere(_groundCheck.position, .1f, _ground );
   }
    bool IsInRamp1()
   {
      return Physics.CheckSphere(_rampCheck.position, .1f, _ramp );
      
   }
   bool IsInRamp2()
   {
      return Physics.CheckSphere(_ramp2Check.position, .1f, _ramp );
      
   }
   
  
   private void Update() 
   {
     IgnoreColliders();
   }
   private void IgnoreColliders()
   {
     if(!IsGrounded() &&  !IsInRamp1() && !IsInRamp2())
     {
        for (int i = 0; i < m_Collider.Length; i++)
        {
            m_Collider[i].enabled = false;
            Debug.Log("false");
        }
     }
    
     if(IsGrounded() || IsInRamp1() || IsInRamp2())
     {
        for (int i = 0; i < m_Collider.Length; i++)
        {
            m_Collider[i].enabled = true;
            Debug.Log("true");
        }
     }
    
   }
 
}
