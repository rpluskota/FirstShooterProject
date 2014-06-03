using UnityEngine;
using System.Collections;

public class PC : Character {

	// Update is called once per frame
	void FixedUpdate () {
		Run(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")); 
		Jump(Input.GetKey(KeyCode.Space));
	}
}
