using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadController : MonoBehaviour
{
    
    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    public bool isAttacking;
    public float attackLength;
    
    private Animator myAnim;
    
    public Vector3 headRespawnPosition;
    
    public LevelManager theLevelManager;
    public float playerHorizontalVelocity;
    public float playerVerticalVelocity;

    
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        
        headRespawnPosition = transform.position;
        theLevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
//         if(Input.GetAxisRaw ("Horizontal") > 0f)
//         {
//             transform.localScale = new Vector3 (-0.2023331f, 0.2023331f, 0.2023331f);
//             
//                 if(Input.GetAxisRaw ("Vertical") > 0f)
//             {
//                 myRigidbody.velocity = new Vector3(moveSpeed/2f, moveSpeed/2f, 0f);
//             } 
//                 else if (Input.GetAxisRaw ("Vertical") < 0f)
//             {
//                 myRigidbody.velocity = new Vector3(moveSpeed/2f, -moveSpeed/2f, 0f);
//             } 
//                 else 
//             {
//                 myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0f);
//             }
//         } 
//         else if (Input.GetAxisRaw ("Horizontal") < 0f)
//         {
//           
//                 transform.localScale = new Vector3(0.2023331f, 0.2023331f, 0.2023331f);
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
//         }
//         else if(Input.GetAxisRaw ("Vertical") > 0f && Input.GetAxisRaw ("Horizontal") == 0f)
//         {
//             myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, moveSpeed, 0f);
//         } 
//         else if (Input.GetAxisRaw ("Vertical") < 0f && Input.GetAxisRaw ("Horizontal") == 0f)
//         {
//             myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, -moveSpeed, 0f);
//         }
//         else {
//             myRigidbody.velocity = new Vector3(0f, 0f, 0f);
//         }
//         
//         if(Input.GetButtonDown ("Jump")) //will use this control for attacking
//         { 
//             isAttacking = true;
//         }
//         myAnim.SetFloat("Horizontal Speed", Mathf.Abs( myRigidbody.velocity.x));
//         myAnim.SetFloat("Vertical Speed", Mathf.Abs( myRigidbody.velocity.y));
                if (Input.GetAxisRaw ("Horizontal") > 0f)
        {
            playerHorizontalVelocity = moveSpeed;
            transform.localScale = new Vector3(-0.2023331f, 0.2023331f, 0.2023331f);
        } 
        else if (Input.GetAxisRaw ("Horizontal") < 0f)
        {
            playerHorizontalVelocity = -moveSpeed;
            transform.localScale = new Vector3(0.2023331f, 0.2023331f, 0.2023331f);
        }
        else if (Input.GetAxisRaw ("Horizontal") == 0f)
        {
            playerHorizontalVelocity = 0f;
        }
        if (Input.GetAxisRaw ("Vertical") > 0f) 
        {
            playerVerticalVelocity = moveSpeed;
        } 
        else if (Input.GetAxisRaw ("Vertical") < 0f) 
        {
            playerVerticalVelocity = -moveSpeed;
        }
        else if (Input.GetAxisRaw ("Vertical") == 0f){
            playerVerticalVelocity = 0f;

        }
        myRigidbody.velocity = new Vector3(playerHorizontalVelocity, playerVerticalVelocity, 0f);

        if(Input.GetButtonDown ("Jump")) //will use this control for attacking
        { 
            isAttacking = true;
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
