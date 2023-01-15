using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Timer : MonoBehaviour
{
    public float timeLeft = 60.0f;
    public TMP_Text countdownText;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip __countDownSound;
    public static bool _canMove = false;

    void Start()
    {
        StartCoroutine(Countdown());
    }
    private void OnEnable() 
    {
        GameManager.Instance.OnDeath += RestartTimer;
        GameManager.Instance.OnLevelEnd += RestartTimer;
    }
    private void RestartTimer()
    {
       timeLeft =3f;
       _canMove = false;
    }

    IEnumerator Countdown()
    {
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
            countdownText.text = timeLeft.ToString();
            _audioSource.PlayOneShot(__countDownSound);
            if(timeLeft <=0)
            {
                countdownText.gameObject.SetActive(false);
                _canMove = true;
                
            }
        }
        // Do something when the timer runs out
    }
}
