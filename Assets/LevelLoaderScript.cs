using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScript : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public bool getLevelFinish;

    void Update()
    {
        getLevelFinish = levelfinisherScript.levelFinish;
    }

    public void LoadNextLevel() 
    {
        
        
            Debug.Log("level finisher 2");
            StartCoroutine(LoadLevel((SceneManager.GetActiveScene().buildIndex + 1)));
        
      
        
    }

    IEnumerator LoadLevel(int levelIndex) 
    {
        Debug.Log("level finisher 3");
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
