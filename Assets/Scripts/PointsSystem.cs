using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class PointsSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _pointsText;
    public static bool _passCircle;
    int _totalLevelPoints = 0;
    
    private void OnEnable() 
    {
        GameManager.Instance.OnDeath +=  OnGameOver;
        GameManager.Instance.OnLevelEnd += CalculatedNewScore;
    }
    
    private int _points;
    private string pointsKey = "Points";

    private void Start() 
    {
        // Get the points from PlayerPrefs
            _pointsText.text = PlayerPrefs.GetInt(pointsKey , _points).ToString();

      
    }
 
  private void OnTriggerEnter(Collider other) 
  {
   

    if(other.CompareTag("Circle") )
    {
       
        _totalLevelPoints += 5;
         _pointsText.text =  (PlayerPrefs.GetInt(pointsKey , _points) + _totalLevelPoints).ToString(); 
         _passCircle = true;  
    }
  }
  private void OnTriggerExit(Collider other) 
  {
    if(other.CompareTag("Circle"))
    {
      _passCircle = false;
    }
  }
  private void OnGameOver()
  {
     _pointsText.text = PlayerPrefs.GetInt(pointsKey , _points).ToString();
     _totalLevelPoints = 0;
  }
  private void CalculatedNewScore()
  {Debug.Log(_points);
    
   // _points += _totalLevelPoints;
    Debug.Log(_points);
    PlayerPrefs.SetInt(pointsKey, PlayerPrefs.GetInt(pointsKey , _points) + _totalLevelPoints);
    Debug.Log(PlayerPrefs.GetInt(pointsKey , _points)+ " " + _points);
    _totalLevelPoints = 0;
    
  }
}



 

