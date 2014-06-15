using UnityEngine;
using System.Collections.Generic;

public class ResetPuzzle : ActivateSwitch {

	public Transform[] objects;

	private Dictionary<string, Vector2> objectsPosition = new Dictionary<string, Vector2>();

	// Use this for initialization
	void Start () {
		foreach(Transform obj in objects){
			objectsPosition[obj.name] = obj.position;
		}
	}
	
	protected override void Activate(){
		foreach (Transform obj in objects) {
			obj.position = objectsPosition[obj.name];
		}
		Type(activateText);
		if (audio) {
			AudioSource.PlayClipAtPoint(audio.clip, transform.position);
		}
	}
}
