using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    float movementSpeed = 1;

    [SerializeField]
    float jumpstrength = 10;

    [SerializeField]
    Transform groundDetectPoint;

    [SerializeField]
    float groundDetectRadius = 0.2f;

    [SerializeField]
    LayerMask whatCountsAsGround;

    Rigidbody2D myRigidBody;

    private bool isOnGround;
    
 
	void Start () {
       
    
        
        myRigidBody = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        UpdateIsOnGround();
        Move();
        Jump();
        
    }

    private void UpdateIsOnGround()
    {
        Collider2D[] groundObjects =  Physics2D.OverlapCircleAll(groundDetectPoint.position, groundDetectRadius, whatCountsAsGround);

        isOnGround = groundObjects.Length > 0;
    }

   


    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            //transform.Translate(0, 5, 0);
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpstrength);
            isOnGround = false;
        }
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        myRigidBody.velocity =
            new Vector2(horizontalInput * movementSpeed, myRigidBody.velocity.y);

        Debug.Log("Horizontal input: " + horizontalInput);
    }
}
