using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cherryScript : MonoBehaviour
{
    public bool cherryGetCollider;
 
    void Update()
    {
        cherryGetCollider = PlayerMovement.cherryCollider;
    }
    public void OnTriggerEnter2D(Collider2D cherryOther)
    {
        if (cherryOther.gameObject.CompareTag("player"))
        {
            if (cherryGetCollider)
            {
                cherryGetCollider = false;
            }
        }
    }
}
