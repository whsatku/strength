using UnityEngine;
using System.Collections;

public class ClickChangeScene : MonoBehaviour {

	public string sceneName;
	public Sprite hover;
	public Sprite normal;

	new private SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
		renderer = (SpriteRenderer) GetComponent("SpriteRenderer");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter(){
		renderer.sprite = hover;
	}

	void OnMouseOver(){
		if(Input.GetMouseButtonDown(0)){

		}
	}
	void OnMouseDown(){
		Application.LoadLevel(sceneName);
	}

	void OnMouseExit(){
		renderer.sprite = normal;
	}
}
