using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject _explosion;
    [SerializeField] private GameObject _explosionObject;
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
            Instantiate(_explosion , _explosionObject.transform.position , _explosionObject.transform.rotation);
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("FallTrigger"))
        {
            gameObject.SetActive(false);
        }
    }
}
