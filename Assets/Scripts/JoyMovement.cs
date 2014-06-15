using UnityEngine;
using System.Collections;

public class JoyMovement : CN2DController {

	public Transform camera;

	override protected void StopMoving()
	{
//		Debug.Log ("Stop!");
		rigidbody2D.velocity = Vector2.zero;	
	}
	
	override protected void StartMoving()
	{

	}

	override protected void Move(Vector3 relativeVector)
	{
//		Debug.Log (relativeVector.x + " " + relativeVector.y + " " + relativeVector.z);
		rigidbody2D.velocity = new Vector2 (relativeVector.x * 3, relativeVector.y * 3);
		FaceMovementDirection ();
	}

	private void FaceMovementDirection(){
		
		float angle = Mathf.Atan2(rigidbody2D.velocity.y, rigidbody2D.velocity.x) * Mathf.Rad2Deg + 180;
		Debug.Log (angle);
		camera.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
	}
}
