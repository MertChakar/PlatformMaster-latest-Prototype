using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int level;
    public int health;
    public float[] position;
    public int gold;
    public int diamond;
    
    
    public PlayerData (PlayerMovement player, ScoreManager scoreManager,diamondScore diamondScore) 
    {
        
        health = PlayerMovement.playerHealth;
        gold = scoreManager.score;
        diamond = diamondScore.diaScore;
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
