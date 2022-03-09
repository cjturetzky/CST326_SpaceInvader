 using System.Collections;
 using UnityEngine;
 using UnityEngine.SceneManagement;
 
 public class LeaveCredits : MonoBehaviour
 {
     public float delay = 6.0f;
     public string NewLevel= "MainMenuScene";
     void Start()
     {
         StartCoroutine(LoadLevelAfterDelay(delay));
     }
 
     IEnumerator LoadLevelAfterDelay(float delay)
     {
         yield return new WaitForSeconds(delay);
         SceneManager.LoadScene(NewLevel);
     }
 }