using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    public  int score=0;

    void Start()
    {
        if (instance==null)
        {
            instance = this;
        }
    }

    void Update()
    {
        
    }
    public void ChangeScore(int value) 
    {
        score =score+ value;
        text.text = "X" + score.ToString();
    }

}
