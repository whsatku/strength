using UnityEngine;
using System.Collections;

public class KeyboardMovement : MonoBehaviour {

	float moveSpeed = 3;

	private bool keyManaged = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 velocity = Vector2.zero;
		if (Input.GetKey ("s")) {
			velocity.y = -moveSpeed;
			keyManaged = true;
		}else if(Input.GetKey("w")){
			velocity.y = moveSpeed;
			keyManaged = true;
		}
		if(Input.GetKey("a")){
			velocity.x = -moveSpeed;
			keyManaged = true;
		}else if(Input.GetKey("d")){
			velocity.x = moveSpeed;
			keyManaged = true;
		}

		// check for managed key to prevent conflict with
		// other movement scripts
		if (keyManaged) {
			rigidbody2D.velocity = velocity;
			if(velocity == Vector2.zero){
				keyManaged = false;
			}
		}
		transform.rotation = Quaternion.identity;
	}
}
