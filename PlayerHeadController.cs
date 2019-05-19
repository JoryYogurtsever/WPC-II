using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadController : MonoBehaviour
{
    
    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    
    public bool canHeadMove;
    
    public bool isAttacking;
    public float attackLength;
    
    private Animator myAnim;
    
    public Vector3 headRespawnPosition;
    
    public LevelManager theLevelManager;
    public float headHorizontalVelocity;
    public float headVerticalVelocity;
    public PlayerController myBody;

    
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myBody = FindObjectOfType<PlayerController>();
        
        headRespawnPosition = transform.position;
        theLevelManager = FindObjectOfType<LevelManager>();
        canHeadMove = true;
    }

    // Update is called once per frame
    void Update()
    {
      if(myBody.knockbackCounter <= 0 && canHeadMove)
        {
            if (Input.GetAxisRaw ("Horizontal") > 0f)
            {
                headHorizontalVelocity = moveSpeed;
                transform.localScale = new Vector3(-0.2023331f, 0.2023331f, 0.2023331f);
            } 
            else if (Input.GetAxisRaw ("Horizontal") < 0f)
            {
                headHorizontalVelocity = -moveSpeed;
                transform.localScale = new Vector3(0.2023331f, 0.2023331f, 0.2023331f);
            }
            else if (Input.GetAxisRaw ("Horizontal") == 0f)
            {
                headHorizontalVelocity = 0f;
            }
            if (Input.GetAxisRaw ("Vertical") > 0f) 
            {
                headVerticalVelocity = moveSpeed;
            } 
            else if (Input.GetAxisRaw ("Vertical") < 0f) 
            {
                headVerticalVelocity = -moveSpeed;
            }
            else if (Input.GetAxisRaw ("Vertical") == 0f){
                headVerticalVelocity = 0f;

            }
            myRigidbody.velocity = new Vector3(headHorizontalVelocity, headVerticalVelocity, 0f);

            if(Input.GetButtonDown ("Jump")) //will use this control for attacking
            { 
                isAttacking = true;
            }
        }
         if(myBody.knockbackCounter > 0)
        {
            if(transform.localScale.x > 0f && Input.GetAxisRaw("Vertical") > 0f)
            {
            myRigidbody.velocity = new Vector3(myBody.knockbackForce, -myBody.knockbackForce, 0f);
            }
            else if(transform.localScale.x <= 0 && Input.GetAxisRaw ("Vertical") > 0f)
            {
            myRigidbody.velocity = new Vector3(-myBody.knockbackForce, -myBody.knockbackForce, 0f);
            }
            else if(transform.localScale.x > 0 && Input.GetAxisRaw ("Vertical") <= 0f)
            {
            myRigidbody.velocity = new Vector3(myBody.knockbackForce, myBody.knockbackForce, 0f);
            }
            else if(transform.localScale.x <= 0 && Input.GetAxisRaw ("Vertical") <= 0f)
            {
            myRigidbody.velocity = new Vector3(-myBody.knockbackForce, myBody.knockbackForce, 0f);
            }
        }
        myAnim.SetFloat("Horizontal Speed", Mathf.Abs( myRigidbody.velocity.x));
        myAnim.SetFloat("Vertical Speed", Mathf.Abs( myRigidbody.velocity.y));
    }
    
//     void OnTriggerEnter2D (Collider2D other) 
//     {
//         if (other.tag == "KillPlane") {
//             gameObject.SetActive(false);
//               transform.position = headRespawnPosition;
//             add some code here to handle the situation where all lives are lost and
//             hero must respawn in the center of town in the main scene
//             Can store first Respawn positions in a variable when she enters
//             new levels, then change the value back after lives are all lost. 
//             theLevelManager.Respawn();
//         }
//     }
    
}
