using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject _explosion;
    [SerializeField] private GameObject _explosionObject;
    [SerializeField] private AudioClip _explSound;
    [SerializeField] private AudioSource _audioSource;
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("sd");
            _audioSource.PlayOneShot(_explSound);
            StartCoroutine(PlayerFalseDelay());
            Instantiate(_explosion , _explosionObject.transform.position , _explosionObject.transform.rotation);
            GameManager.Instance.Death();
        }
    }
    
    IEnumerator PlayerFalseDelay()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
    }
}
