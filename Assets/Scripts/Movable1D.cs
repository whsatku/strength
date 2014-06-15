using UnityEngine;
using System.Collections;

public class Movable1D : MonoBehaviour {

	private bool isX = false;
	private float lastDirectionChange;
	private float otherDirectionValue;
	
	// Update is called once per frame
	void Update () {
		if (rigidbody2D.velocity.x != 0 && rigidbody2D.velocity.y != 0) {
			Vector2 velocity = Vector2.zero;
			Vector2 position = new Vector2(rigidbody2D.position.x, rigidbody2D.position.y);
			if(Time.time - lastDirectionChange > 0.5){
				if(Mathf.Abs(rigidbody2D.velocity.x) > Mathf.Abs(rigidbody2D.velocity.y)){
					isX = true;
					otherDirectionValue = rigidbody2D.position.y;
				}else{
					isX = false;
					otherDirectionValue = rigidbody2D.position.x;
				}
				lastDirectionChange = Time.time;
			}

			if(isX){
				velocity.x = rigidbody2D.velocity.x;
				position.y = otherDirectionValue;
			}else{
				velocity.y = rigidbody2D.velocity.y;
				position.x = otherDirectionValue;
			}

			rigidbody2D.velocity = velocity;
			rigidbody2D.position = position;
		}
	}
}
