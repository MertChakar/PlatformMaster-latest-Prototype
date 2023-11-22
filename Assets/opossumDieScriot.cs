using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opossumDieScriot : MonoBehaviour
{
    private Animator opossumAnimator;
    public GameObject fullOpossum;
    void Start()
    {
        opossumAnimator = gameObject.GetComponent<Animator>();

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D fareCollision)
    {
        if (fareCollision.CompareTag("player"))
        {
            Debug.Log("Deðdi");
            opossumAnimator.SetBool("fareDead", true);
        }
    }

    public void Destroyy()
    {
        Debug.Log("Farenin destroy çalýþtý");
        Destroy(fullOpossum);
        PlayerMovement.opossumNoDamage = 0;
    }

   
}
