using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager1 : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _totalPoint;

   private void Start() 
   {
     _totalPoint.text = PlayerPrefs.GetInt("totalpoints").ToString();
   }
}
