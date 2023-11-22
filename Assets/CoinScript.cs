using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public int coinValue = 1;
    public bool getCollider;

    private void Update()
    {
        getCollider = PlayerMovement.Coincollider;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            if (getCollider)
            {
                ScoreManager.instance.ChangeScore(coinValue);
                getCollider = false;
            }
        }
    }
}
