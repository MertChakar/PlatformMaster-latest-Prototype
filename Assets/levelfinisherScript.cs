using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelfinisherScript : MonoBehaviour
{
    public static bool levelFinish;
    public GameObject levelScript;
    void Start()
    {
        levelFinish = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D levelFinisher)
    {
        if (levelFinisher.CompareTag("player"))
        {
            Debug.Log("Level Finisher Bura");
            levelFinish = true;
            levelScript.GetComponent<LevelLoaderScript>().LoadNextLevel();

            Destroy(this);
        }
    }
}
