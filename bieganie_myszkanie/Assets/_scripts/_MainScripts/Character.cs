using UnityEngine;
using System.Collections;


public class Character : InteractiveObject {

	public bool isGrounded;

	/// <summary>
	/// Run
	/// Use this function to move object.
	/// </summary>
	/// <param name="hori">Hori. turning left, right values from -1.0f to 1.0f (-1:left, 0:nothing, 1:right)</param>
	/// <param name="verti">Verti. values from -1.0f to 1.0f (-1:back, 0:nothing, 1:forward)</param>
	protected void Run (float hori, float verti) { 
		
		transform.position += transform.TransformDirection(	0.8f*RM.playerSpeed*hori,	// move along object's X axis (turn)
		                                                   	0,							//move along OBJECT's Y axis
		                                                   	RM.playerSpeed*verti); 		//move along OBJECT's Z axis (run forward)
	}

	/// <summary>
	/// Jump the specified ifJump.
	/// </summary>
	/// <param name="ifJump">If set to <c>true</c> and isGrounded object will Jump.</param>
	protected void Jump(bool ifJump){	//to jump object must have collision with "floor" and ifJump must be _true_
		if(ifJump && isGrounded){
			rigidbody.AddForce(Vector3.up*RM.playerJumpForce);		// to jump add force to rigidbody
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
