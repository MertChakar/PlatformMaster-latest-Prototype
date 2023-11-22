using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    GameObject playerObj;
    GameObject scoreObj;
    GameObject diaObj;
    public PlayerMovement menuPlayerObj;

    
    public void Playgame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    
    public void quitGame() 
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }

    public void LoadPlayer()
    {
        menuPlayerObj.LoadPlayer();
    }
}
