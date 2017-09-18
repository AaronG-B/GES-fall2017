using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    float movementSpeed = 1;
    [SerializeField]
    Rigidbody2D myRigidBody;
 
	void Start () {
       
    
        
        myRigidBody = GetComponent<Rigidbody2D>();
	}
	
	void Update () {

       

        float horizontalInput = Input.GetAxis("Horizontal");
        myRigidBody.velocity = 
            new Vector2(horizontalInput * movementSpeed,  myRigidBody.velocity.y);

        //this does not use the unity physics system
        //transform.Translate(0.1f * horizontalInput, 0, 0);

        if (Input.GetButtonDown("Jump"))
        {
            transform.Translate(0, 5, 0);
        }

       
    }
}
