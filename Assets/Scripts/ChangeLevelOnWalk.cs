using UnityEngine;
using System.Collections;

public class ChangeLevelOnWalk : MonoBehaviour {

	public string levelName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag.Contains("Player")){
			Application.LoadLevel(levelName);
		}
	}
}
