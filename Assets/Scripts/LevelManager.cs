using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

   private void OnEnable() 
   {
     GameManager.Instance.OnLevelEnd += UIScene;
   }


   private void UIScene()
   {
     SceneManager.LoadScene("UIScene" , LoadSceneMode.Additive);
   }
}
