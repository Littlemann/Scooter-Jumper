using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableImages : MonoBehaviour
{
  [SerializeField] private GameObject _leftImage1;
  [SerializeField] private GameObject _leftImage2;
  
  [SerializeField] private GameObject _rightImage1;
  [SerializeField] private GameObject _rightImage2;
  

  private void Update() 
  {
    if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x > Screen.width / 2)
            {
               _rightImage1.SetActive(false);
                _rightImage2.SetActive(false);
                
            }
            else if (touch.position.x < Screen.width / 2)
            {
                
                _leftImage1.SetActive(false);
               _leftImage2.SetActive(false);
               
            }
        }
  }
  
}
