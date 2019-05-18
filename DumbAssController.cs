using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbAssController : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    
    public float moveSpeed;
    
    private Rigidbody2D myRigidBody;
    
    public bool movingRight;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(movingRight && transform.position.x > endPoint.position.x) 
        {
            movingRight = false;
        }
        if(!movingRight && transform.position.x < startPoint.position.x)
        {
            movingRight = true;
        }
        if(movingRight) 
        {
            myRigidBody.velocity = new Vector3(moveSpeed, 0f, 0f);
        }
        else
        {
            myRigidBody.velocity = new Vector3(-moveSpeed, 0f, 0f);
        }
    }
}
