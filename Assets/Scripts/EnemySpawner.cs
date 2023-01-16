using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;


    private void Start() 
    {
      
        InvokeRepeating("Spawn" , 3f , 3f);
    }
   
   private void Spawn()
   {
    Instantiate(_enemy , transform.position ,transform.rotation);
   }
   
}
