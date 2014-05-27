/*
	@author:	Daniel Koprowski
	@site:		koprowski.it
	@date:		27.05.2014

Ground, terrain etc must be named "floor".
Object must have Rigidbody component.
	
 */
using UnityEngine;
using System.Collections;

public class wasd : MonoBehaviour {

	public float speed = 0.17f;
	public float jumpForce = 115f;
//	public GUIText debugText;
	public bool isGrounded;
	
	void FixedUpdate () {

		Run();
		Jump();

	}


	void Run () {

		transform.position += transform.TransformDirection(	0.8f*speed*Input.GetAxis("Horizontal"),	// move along object's X axis (turn)
		                                                   	0,										//move along OBJECT's Y axis
		                                                   	speed*Input.GetAxis("Vertical")); 		//move along OBJECT's Z axis (run forward)
	}

	void Jump(){
		if(Input.GetKey(KeyCode.Space) && isGrounded){
			rigidbody.AddForce(Vector3.up*jumpForce);		// to jump add force to rigidbody
		}
	}

	void OnCollisionEnter(Collision coll){
		if(coll.gameObject.name == "floor")					// if your ground have a different name you can change it here
			isGrounded = true;
	}

	void OnCollisionExit(Collision coll){
		if(coll.gameObject.name == "floor")					//.... and here :D
			isGrounded = false;
	}

}
