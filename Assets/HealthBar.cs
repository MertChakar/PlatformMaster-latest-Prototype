using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public int getHealth=10;
    public GameObject heatlhBarObj;
    public PlayerMovement Healthplayer;
    GameObject bos;
    
    public void setMaxHealth(int Maxhealth) 
    {
        slider.maxValue = Maxhealth;
        slider.value = Maxhealth;
    }

    void Start()
    {
        
    }

    void Update()
    {
        getHealth = PlayerMovement.playerHealth;
        setHealth(getHealth);
    }
    public void setHealth(int Health) 
    {
        slider.value = Health;
    }
}
