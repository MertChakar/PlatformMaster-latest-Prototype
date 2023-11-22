using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    //public Animator eagleAnimator;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;
    public bool trigger = false;
    public static bool Coincollider = true;
    public static bool diaCollider = true;
    public static bool cherryCollider = true;
    //public static bool opossumDie = false;
    private int control = 0;
    public GameObject obje;
    public GameObject opossum;
    Rigidbody2D rb;
    opossumAIPatrol op;
    public  static int playerHealth = 3;
    private int opossumControl = 0;
    public static int eagleNoDamage;
    public static int opossumNoDamage;
    public TextMeshProUGUI savingText;
    public Animator saveTextAnim;

    private float timeToAppear = 4f;
    private float timeWhenDisappear;
    
    //opossumAIPatrol op;
    void Start()
    {
        //eagleAnimator = gameObject.GetComponent<Animator>();
        control = PlayerPrefs.GetInt("enemyControl");
        opossumControl = PlayerPrefs.GetInt("opossumControl");
        rb =GetComponent<Rigidbody2D>();
        eagleNoDamage = 0;
        opossumNoDamage =0;
        savingText.enabled = false;
    }

    void Update()
    {
        horizontalMove= Input.GetAxisRaw("Horizontal")*runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJump", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        if (savingText.enabled && (Time.time >= timeWhenDisappear))
        {
            savingText.enabled = false;
        }


    }
    public void onLand()
    {
        animator.SetBool("isJump", false);
    }
    public void onCrouch(bool controlCrouch) 
    {
        animator.SetBool("isCrouch", controlCrouch);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime,crouch,jump);
        jump = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            Destroy(other.gameObject);
            trigger = true;
            Coincollider = true;
        }
        if (other.gameObject.CompareTag("diamond")) 
        {
            Destroy(other.gameObject);
            diaCollider = true;
        }
        control = 1;
        if (other.CompareTag("enemyEagle"))
        {
            if (eagleNoDamage==0)
            {
                control = 0;
                if (playerHealth < 1)
                {
                    Destroy(this.gameObject);
                }
                else
                {
                    playerHealth -= 5;
                    if (playerHealth < 1)
                    {
                        Destroy(this.gameObject);
                    }
                }
            }
            
        }
        if (other.CompareTag("eagle"))
        {
            //eagleAnimator.SetBool("isDead", true);
            if (control==1)
            {
                eagleNoDamage = 1;
                control = 1;
                rb.AddForce(transform.up * 5f);
                PlayerPrefs.SetInt("enemyControl", control);
                //onDamage();
            }
        }
        if (other.CompareTag("cherry"))
        {
            Destroy(other.gameObject);
            playerHealth += 3;
            cherryCollider = false;
        }
        opossumControl = 1;
        if (other.CompareTag("enemyopossum"))
        {
            opossumControl = 0;
            if (opossumNoDamage==0)
            {
                if (playerHealth < 1)
                {
                    Destroy(this.gameObject);
                }
                else
                {
                    playerHealth -= 1;
                    if (playerHealth < 1)
                    {

                        Destroy(this.gameObject);
                    }
                }
            }
        }

        if (other.CompareTag("opossum"))
        {

            if (opossumControl == 1)
            {
                opossumNoDamage =1;
                //Destroy(opossum);
            }

        }

        if (other.CompareTag("savestar"))
        {
            
            ScoreManager scoremanager;
            diamondScore diamondscore;
            Debug.Log("Bura çalýþtý");

            
            scoremanager = gameObject.AddComponent<ScoreManager>();
            diamondscore = gameObject.AddComponent<diamondScore>();


            SaveSystem.savePlayer(this,scoremanager, diamondscore);
            Destroy(other.gameObject);

            
            enableText();
        }

    }
    

    public void enableText() 
    {
        savingText.enabled = true;
        saveTextAnim.enabled = true;
        timeWhenDisappear = Time.time + timeToAppear;
        
    }

    public void LoadPlayer()
    {
        Debug.Log("Load Player Çalýþtý");
        PlayerData data = SaveSystem.LoadPlayer();
        int playerHealth = data.health;

        int playerGold = data.gold;

        int playerDia = data.diamond;

        Vector3 position;
        position.x = data.position[0];
        Debug.Log(position.x);
        position.y = data.position[1];
        Debug.Log(position.y);
        position.z = data.position[2];
        Debug.Log(position.z);
        transform.position.Set(position.x, position.y, position.z);

    }


    private void onDamage()
    {
        if (control == 1)
        {
            Destroy(obje);            
        }
    }

    //public int returnHealth() 
    //{
    //    int playerHealth = this.playerHealth;
    //    return playerHealth;
    //}




}
