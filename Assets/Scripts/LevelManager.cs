using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

   private void OnEnable() 
   {
     GameManager.Instance.OnLevelEnd += UIScene;
       GameManager.Instance.OnDeath += LoadSameLevel;
   }
 //  private void OnDisable() 
 //  {
 //    GameManager.Instance.OnDeath -= LoadSameLevel;
 //  }


   private void UIScene()
   {
     StartCoroutine(LoadUISceneTime());
   }

   IEnumerator LoadUISceneTime()
   {
     yield return new WaitForSeconds(2f);
     SceneManager.LoadScene("Level1UI" , LoadSceneMode.Additive);
   }
   public void NextSceneButton()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  
   }
   public void LoadSameLevel()
   {
      StartCoroutine(LoadSameLevelDelay());
   }
   IEnumerator LoadSameLevelDelay()
   {
    yield return new WaitForSeconds(1f);
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  
   }
}
