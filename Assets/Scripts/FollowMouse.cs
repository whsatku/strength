using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName != "MainMenu") {
#if UNITY_ANDROID && !UNITY_EDITOR
			return;
#endif
		}
		float cameraDiff = Camera.main.transform.position.y - transform.position.y;
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		Vector3 mWorldPos = Camera.main.ScreenToWorldPoint( new Vector3(mouseX, mouseY, cameraDiff));
		
		float diffX = mWorldPos.x - transform.position.x;
		float diffY = mWorldPos.y - transform.position.y;
		
		float angle = Mathf.Atan2(diffY, diffX) * Mathf.Rad2Deg +180;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));

	}
}
