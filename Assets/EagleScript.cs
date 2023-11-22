using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EagleScript : MonoBehaviour
{
    public AIPath aiPath;
    private Animator eagleAnimator;
    public GameObject fullEagle;

    void Start()
    {
        eagleAnimator= gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (aiPath.desiredVelocity.x>=0.01f)
        {
            transform.localScale = new Vector3(-3f, 3f, 3f);
        }   
        else if (aiPath.desiredVelocity.x <= -0.01f) 
        {
            transform.localScale = new Vector3(3f, 3f, 3f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {

            Debug.Log("Deðdi");
            eagleAnimator.SetBool("isDead", true);
        }
    }

    public void Destroyy ()
    {
        Destroy(fullEagle);
        PlayerMovement.eagleNoDamage = 0;
    }


}
