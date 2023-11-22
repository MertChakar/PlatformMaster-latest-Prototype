using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opossumAIPatrol : MonoBehaviour
{
   
    public float walkSpeed;
    [HideInInspector]
    public bool mustPatrol;
    public Rigidbody2D opossumRB;
    public Transform groundCheckPos;
    private bool mustTurn;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;
    public bool getOpossumDie;
    public GameObject getOpossumGameObject;

    void Start()
    {
        mustPatrol = true;
        
    }

    void Update()
    {
        //getOpossumDie = PlayerMovement.opossumDie;
        if (mustPatrol)
        {
            Patrol();
        }
        //if (getOpossumDie)
        //{
        //    Die();
        //}
        
    }
    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }
    void Patrol() 
    {
        if (mustTurn)
        {
            Flip();
        }
        opossumRB.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, opossumRB.velocity.y);
    }
    void Flip() 
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }

    public void Die(bool deger)
    {
        if (deger)
        {
            //Destroy(getOpossumGameObject);
            //getOpossumDie = false;
        }

    }

   

   
}
