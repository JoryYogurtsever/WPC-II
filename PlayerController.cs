using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float moveSpeed;
    public Rigidbody2D myRigidbody;
    
    public bool canMove;
    
    public bool isAttacking;
    public float attackLength;
    
    private Animator myAnim;
    
    public Vector3 bodyRespawnPosition;
    
    public LevelManager theLevelManager;
//     public Yogurt theYogurt;
//     public Vector3 playerVelocity;
    public float playerHorizontalVelocity;
    public float playerVerticalVelocity;
    
    public float knockbackForce;
    public float knockbackLength;
    public float knockbackCounter;
    
    public AudioSource hurtSound;
    

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        
        bodyRespawnPosition = transform.position;
        theLevelManager = FindObjectOfType<LevelManager>();
//         theYogurt = FindObjectOfType<Yogurt>();
//         playerVelocity = new Vector3(0f, 0f, 0f);
        playerHorizontalVelocity = 0f;
        playerVerticalVelocity = 0f;
        knockbackCounter = 0f;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
//         Debug.Log(Input.GetAxisRaw ("Horizontal"));
        if(knockbackCounter <= 0 && canMove)
        {
            if (Input.GetAxisRaw ("Horizontal") > 0f)
            {
                playerHorizontalVelocity = moveSpeed;
                transform.localScale = new Vector3(-2.349521f, 2.349521f, 2.349521f);
                //comment out everything below here, and make two variables to determine
                //horizontal and vertical inputs then make the vector3 in accordance to 
                //these values below
            /* 
                    if(Input.GetAxisRaw ("Vertical") > 0f)
                {
                    myRigidbody.velocity = new Vector3(moveSpeed/2f, moveSpeed/2f, 0f);
                } 
                    else if (Input.GetAxisRaw ("Vertical") < 0f)
                {
                    myRigidbody.velocity = new Vector3(moveSpeed/2f, -moveSpeed/2f, 0f);
                } 
                    else 
                {
                    myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0f);
                }*/
            } 
            else if (Input.GetAxisRaw ("Horizontal") < 0f)
            {
                playerHorizontalVelocity = -moveSpeed;
                transform.localScale = new Vector3(2.349521f, 2.349521f, 2.349521f);
                    
    //                 if(Input.GetAxisRaw ("Vertical") > 0f)
    //             {
    //                 myRigidbody.velocity = new Vector3(-moveSpeed/2f, moveSpeed/2f, 0f);
    //             } 
    //                 else if (Input.GetAxisRaw ("Vertical") < 0f)
    //             {
    //                 myRigidbody.velocity = new Vector3(-moveSpeed/2f, -moveSpeed/2f, 0f);
    //             }   else
    //             {
    //                 myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
    //             }
            }
            else if (Input.GetAxisRaw ("Horizontal") == 0f)
            {
                playerHorizontalVelocity = 0f;
            }
            if (Input.GetAxisRaw ("Vertical") > 0f) // && Input.GetAxisRaw ("Horizontal") == 0f)
            {
    //             myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, moveSpeed, 0f);
                playerVerticalVelocity = moveSpeed;
            } 
            else if (Input.GetAxisRaw ("Vertical") < 0f) // && Input.GetAxisRaw ("Horizontal") == 0f)
            {
    //             myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, -moveSpeed, 0f);
                playerVerticalVelocity = -moveSpeed;
            }
            else if (Input.GetAxisRaw ("Vertical") == 0f){
                playerVerticalVelocity = 0f;
    //             playerHorizontalVelocity = 0f;
    //             myRigidbody.velocity = new Vector3(0f, 0f, 0f);
            }
            myRigidbody.velocity = new Vector3(playerHorizontalVelocity, playerVerticalVelocity, 0f);

            if(Input.GetButtonDown ("Jump")) //will use this control for attacking
            { 
                isAttacking = true;
            }
            theLevelManager.invincible = false;
        }
        
        if(knockbackCounter > 0)
        {
            knockbackCounter -= Time.deltaTime;
            if(transform.localScale.x > 0f && Input.GetAxisRaw("Vertical") > 0f)
            {
            myRigidbody.velocity = new Vector3(knockbackForce, -knockbackForce, 0f);
            }
            else if(transform.localScale.x <= 0 && Input.GetAxisRaw ("Vertical") > 0f)
            {
            myRigidbody.velocity = new Vector3(-knockbackForce, -knockbackForce, 0f);
            }
            else if(transform.localScale.x > 0 && Input.GetAxisRaw ("Vertical") <= 0f)
            {
            myRigidbody.velocity = new Vector3(knockbackForce, knockbackForce, 0f);
            }
            else if(transform.localScale.x <= 0 && Input.GetAxisRaw ("Vertical") <= 0f)
            {
            myRigidbody.velocity = new Vector3(-knockbackForce, knockbackForce, 0f);
            }
        }
//         playerVelocity = new Vector3(myRigidbody.velocity.x, myRigidbody.velocity.y, 0f);
        myAnim.SetFloat("Horizontal Speed", Mathf.Abs( myRigidbody.velocity.x));
        myAnim.SetFloat("Vertical Speed", Mathf.Abs( myRigidbody.velocity.y));
    }
    
    public void Knockback()
    {
        knockbackCounter = knockbackLength;
        theLevelManager.invincible = true;
    }
    
    void OnTriggerEnter2D (Collider2D other) 
    {
        if (other.tag == "KillPlane") {
            //gameObject.SetActive(false);
//                 transform.position = bodyRespawnPosition;
            // JUST LOADING THE NEW SCENE SHOULD RESTART THE PLAYER AT THE START POSITION
            // NO NEED TO WORRY ABOUT THIS IN THE RESPAWN FUNCTIONS
            // add some code here to handle the situation where all lives are lost and
            // hero must respawn in the center of town in the main scene
            // Can store first Respawn positions in a variable when she enters
            // new levels, then change the value back after lives are all lost. 
            theLevelManager.Respawn();
        }
        else if (other.tag == "InfinityStone")
        {
            theLevelManager.InfinityGauntletMeter();
            other.gameObject.SetActive(false);
        }
    }
    
}
