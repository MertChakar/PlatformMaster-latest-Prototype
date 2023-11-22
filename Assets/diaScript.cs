using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diaScript : MonoBehaviour
{
    public int diaValue = 1;
    public bool diaGetCollider;

    private void Update()
    {
        diaGetCollider = PlayerMovement.diaCollider;
    }

    public void OnTriggerEnter2D(Collider2D diaOther)
    {
        if (diaOther.gameObject.CompareTag("player"))
        {
            if (diaGetCollider)
            {
                diamondScore.diaInstance.diaChangeScore(diaValue);
                diaGetCollider = false;
            }
        }
    }
}
