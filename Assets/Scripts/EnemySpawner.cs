using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;


    private void Start() 
    {
       StartCoroutine(CDSpawn());
    }
    IEnumerator CDSpawn()
    {
        yield return new WaitForSeconds(3f);
         
        Instantiate(_enemy , transform.position , transform.rotation);
    }
   
}
