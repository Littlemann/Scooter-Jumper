using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class PointsSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _pointsText;
    [SerializeField] AudioClip collectSound;

	  [SerializeField] GameObject collectEffect;

    private int _points;

    private void Start() 
    {
        _points = 0;
        PlayerPrefs.SetInt("totalpoints" , 0);
    }
    private void Update() 
    { 
        _pointsText.text = PlayerPrefs.GetInt("starpoints").ToString(); 
        PlayerPrefs.SetInt("totalpoints" , PlayerPrefs.GetInt("starpoints") + PlayerPrefs.GetInt("points"));
    }
  private void OnTriggerEnter(Collider other) 
  {
    
    if(other.CompareTag("Circle"))
    {
        _points += 5;
        PlayerPrefs.SetInt("starpoints" , _points);
        Collect ();   
    }
  }
 

  public void Collect()
	{
			AudioSource.PlayClipAtPoint(collectSound, transform.position);
		
			Instantiate(collectEffect, transform.position, Quaternion.identity);
	}
  
}
