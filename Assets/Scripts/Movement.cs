using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
   
   private float _inputHorizontal;
   private Animator _manAnim;
   private Animator _skateAnim;
   [SerializeField] private float _speed;
   [SerializeField] private float _turnSpeed;
   [SerializeField] private Transform _groundCheck;
   [SerializeField] private Transform _rampCheck;
   [SerializeField] private Transform _ramp2Check;
   [SerializeField] private LayerMask _ground;
   [SerializeField] private LayerMask _ramp;
   [SerializeField] private ParticleSystem _turning;
   [SerializeField] private ParticleSystem _finish;
   [SerializeField] private ParticleSystem _wind;
   
   
   private bool _levelDone = false;
   private bool _grounded =true ;
   private Rigidbody _myRb;


   private void Start() 
   {
     _myRb = GetComponent<Rigidbody>();
      _manAnim = this.gameObject.transform.GetChild(0).GetComponent<Animator>();
      _skateAnim = this.gameObject.transform.GetChild(1).GetComponent<Animator>();
       
        
     
   }
   private void Update() 
   {
     
     Jump();
     GroundCheck();
     _turning.transform.position = transform.position;
     
   }
    private void FixedUpdate() 
  {
    Move();
    
   }
   private void Move()
   { if(!_levelDone)
   {
      _inputHorizontal = Input.GetAxis("Horizontal");
        _myRb.velocity = new Vector3(_myRb.velocity.x, _myRb.velocity.y, _speed);
        
        if(IsGrounded())
        {
          _myRb.constraints =  RigidbodyConstraints.FreezeRotation;
         
         
           
        }
        if(!IsGrounded() && !IsInRamp1() && !IsInRamp2())
        {
          _myRb.constraints =  RigidbodyConstraints.FreezeRotation;
           transform.rotation = Quaternion.identity;
        
         
          transform.Translate(Vector3.forward * Time.deltaTime *_speed ,Space.World );
        }
        if(IsInRamp1() || IsInRamp2())
        {
           _myRb.constraints =  RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
           
        }
         
        _myRb.velocity = new Vector3(_inputHorizontal * _turnSpeed, _myRb.velocity.y, _myRb.velocity.z);
   }
        
   }
   private void Jump()
   {
     if(Input.GetKeyDown(KeyCode.Space) && _grounded && !IsGrounded())
     {
        _grounded = false;
       _manAnim.SetTrigger("Flip");
       _turning.Play(true);
       
        
     }
     if(Input.GetKeyDown(KeyCode.T) && _grounded && !IsGrounded())
     {
       _grounded = false;
       _manAnim.SetTrigger("Right");
       _turning.Play(true);
     }
     if(Input.GetKeyDown(KeyCode.Y) && _grounded && !IsGrounded())
     {
       _grounded = false;
       _manAnim.SetTrigger("Jump");
       _skateAnim.SetTrigger("Jump");
       _turning.Play(true);
     }
   }

   bool IsGrounded()
   {
     return Physics.CheckSphere(_groundCheck.position, .1f, _ground );
   }
   private void GroundCheck()
   {
     if(Physics.CheckSphere(_groundCheck.position, .1f, _ground ))
     {
       _grounded = true;
     }
   }
   bool IsInRamp1()
   {
      return Physics.CheckSphere(_rampCheck.position, .1f, _ramp );
      
   }
   bool IsInRamp2()
   {
      return Physics.CheckSphere(_ramp2Check.position, .1f, _ramp );
      
   }
   private void OnTriggerEnter(Collider other) 
   {
     
     if(other.CompareTag("Finish"))
     {
      _finish.Play(true);
       GameManager.Instance.LevelFinish();
       _levelDone = true;
     }
   }
 
}
