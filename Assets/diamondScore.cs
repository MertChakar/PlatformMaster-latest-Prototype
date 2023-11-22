using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class diamondScore : MonoBehaviour
{
    public static diamondScore diaInstance;
    public TextMeshProUGUI diaText;
    public  int diaScore;
        
    void Start()
    {
        if (diaInstance==null)
        {
            diaInstance = this;
        }
    }

    public void diaChangeScore (int diaValue)
    {
        diaScore = diaValue;
        diaText.text = "X" + diaScore.ToString();
    }
}
